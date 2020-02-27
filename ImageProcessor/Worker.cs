using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ImageProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var sqsClient = new AmazonSQSClient();
                var sqsResponse = await sqsClient.ReceiveMessageAsync(
                    "https://sqs.us-east-1.amazonaws.com/675681942151/success");
                if (sqsResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    foreach (var message in sqsResponse.Messages)
                    {
                        var fileName = message.Body.Replace("name: ", "").Trim('\'');
                        var s3Client = new AmazonS3Client();

                        var s3Request = new GetObjectRequest
                        {
                            BucketName = "practicenet",
                            Key = fileName
                        };

                        var response = await s3Client.GetObjectAsync(s3Request);
                        var token = new CancellationToken();
                        await response.WriteResponseStreamToFileAsync(fileName, false, token);

                        var deleteQueueItemRequest = new DeleteMessageRequest(
                            "https://sqs.us-east-1.amazonaws.com/675681942151/success",
                            message.ReceiptHandle);
                        await sqsClient.DeleteMessageAsync(deleteQueueItemRequest);

                        _logger.LogInformation($"File Name: {fileName} at: {DateTimeOffset.Now}");

                        using var dbHelper = new DynamoDbHelper();
                        await dbHelper.Insert(new DbInsertItem
                        {
                            TableName = "test",
                            Values = new Dictionary<string, object>
                            {
                                {
                                    "id", Guid.NewGuid().ToString()
                                },
                                {
                                    "fileName", fileName
                                },
                                {
                                    "time", DateTimeOffset.Now
                                }
                            }
                        });
                    }

                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
