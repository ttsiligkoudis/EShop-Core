using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace EShop.Helpers
{
    public class GoogleDrive
    {
        private readonly string[] _scopes = { DriveService.Scope.Drive };
        private readonly string _applicationName = "EShop Google Drive";
        private string _folder { get; set; }
        private UserCredential _credential { get; set; }
        private DriveService _service { get; set; }
        private IConfiguration _configuration { get; set; }

        public GoogleDrive(IConfiguration configuration)
        {
            _configuration = configuration;  
        }

        public async Task GetService()
        {

            using (var stream = new FileStream("GDriveCreds.json", FileMode.Open, FileAccess.Read))
            {
                _credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        new ClientSecrets
                        {
                            ClientId = _configuration["Authentication:GDrive:ClientId"],
                            ClientSecret = _configuration["Authentication:GDrive:ClientSecret"],
                        },
                        _scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore("token.json", true));
            }

            _service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = _credential,
                ApplicationName = _applicationName,
            });
        }

        public async Task<string> UploadFile(IFormFile file, Category category)
        {
            _folder = category switch
            {
                Category.Laptops => "1e5aWKktHGnFyK3p6f0UDxBI5mq2XCbfM",
                Category.Tablets => "1XL5cxZlAjUCp2BsXkLcPU0a6FSJfv3kO",
                Category.Smartphones => "19JCBkBEYYy8a5xUgxBNKb1YdSK712EKX",
                _ => string.Empty,
            };

            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = file.FileName,
                Parents = new List<string> { _folder }
            };

            await GetService();

            FilesResource.CreateMediaUpload request;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                request = _service.Files.Create(fileMetadata, stream, file.ContentType);
                request.Fields = "id";
                await request.UploadAsync();
            }

            return $"https://drive.google.com/uc?id={request.ResponseBody.Id}";
        }
    }
}
