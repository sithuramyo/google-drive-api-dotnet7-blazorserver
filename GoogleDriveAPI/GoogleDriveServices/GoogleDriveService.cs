using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace GoogleDriveAPI.GoogleDriveServices
{
    public class GoogleDriveService
    {
        private readonly IConfiguration _configuration;
        private readonly string credentialFile = "GoogleDriveAPICredential.json";
        public GoogleDriveService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DriveService GetGoogleDriveService()
        {
            GoogleCredential credential;
            using (var stream = new FileStream(credentialFile, FileMode.Open,
                FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream)
                            .CreateScoped(new[] { DriveService.Scope.Drive });
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Drive API"
            });
            return service;
        }

        public string GetGoogleDriveFolderId()
        {
            return _configuration["GoogleDriveFolderId"];
        }

        public async Task<string> UploadToGoogleDrive(string filePath, Google.Apis.Drive.v3.Data.File fileMetadata)
        {
            var service = GetGoogleDriveService();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                FilesResource.CreateMediaUpload request;
                request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                request.Fields = "id";

                // Upload the file
                var uploadProgress = await request.UploadAsync();
                if (uploadProgress.Status == UploadStatus.Completed)
                {
                    Console.WriteLine("File uploaded successfully.");
                    Console.WriteLine($"File ID: {request.ResponseBody.Id}");
                    return request.ResponseBody.Id;
                }
                else
                {
                    Console.WriteLine("File upload failed.");
                    return string.Empty;
                }
            }
        }
    }
}
