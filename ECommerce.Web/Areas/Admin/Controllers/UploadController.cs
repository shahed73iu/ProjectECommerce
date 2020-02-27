using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile profileImage)
        {
            var randomName = Path.GetRandomFileName().Replace(".", "");
            var fileName = System.IO.Path.GetFileName(profileImage.FileName);
            var newFileName = $"{ randomName }{ Path.GetExtension(profileImage.FileName)}";

            var path = $"upload/{randomName}{Path.GetExtension(profileImage.FileName)}";

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

            var client = new AmazonS3Client();

            var file = new FileInfo(path);
            var request = new PutObjectRequest
            {
                BucketName = "practicenet",
                FilePath = file.FullName,
                Key = newFileName
            };

            var response = await client.PutObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                var sqsClient = new AmazonSQSClient();
                var sqsRequest = new SendMessageRequest
                {
                    QueueUrl = "https://sqs.us-east-1.amazonaws.com/675681942151/success",
                    MessageBody = $"name: '{newFileName}'"
                };

                var sqsResponse = await sqsClient.SendMessageAsync(sqsRequest);
                if (sqsResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    file.Delete();
                }
            }

            return View();
        }
    }
}