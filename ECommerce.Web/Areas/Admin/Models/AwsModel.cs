using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace ECommerce.Web.Areas.Admin.Models
{
    public class AwsModel
    {
        public string BucketName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Boolean Response { get; set; }
        public String Qstring { get; set; }


        public void FileUpload(IFormFile profileImage)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(profileImage.FileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(profileImage.FileName)}";
            FileName = newFileName;
            var path = $"wwwroot/upload/{randomName}{Path.GetExtension(profileImage.FileName)}";
            FilePath = path;
            if (!System.IO.File.Exists(path))
            {
                using (var imageFile = System.IO.File.OpenWrite(path))
                {
                    using (var uploadedfile = profileImage.OpenReadStream())
                    {
                        uploadedfile.CopyTo(imageFile);

                    }
                }
            }
        }
        public async Task AddPictureInS3Bucket()
        {
            var client = new AmazonS3Client();

            var file = new FileInfo(FilePath);
            var request = new PutObjectRequest
            {
                BucketName = "",
                FilePath = file.FullName,
                Key = FileName
            };

            var response = await client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                Response = true;
            }

        }

        public async Task AddinInQueue()
        {
            if (Response)
            {
                var sqsClient = new AmazonSQSClient();
                Qstring = "https://sqs.us-east-1.amazonaws.com/847888492411/rakib01";
                var sqsRequest = new SendMessageRequest
                {
                    QueueUrl = Qstring,
                    MessageBody = $"name: '{FileName}'"
                };

                var sqsResponse = await sqsClient.SendMessageAsync(sqsRequest);
                var file = new FileInfo(FilePath);
                if (sqsResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    file.Delete();
                }
            }
        }
    }
}
