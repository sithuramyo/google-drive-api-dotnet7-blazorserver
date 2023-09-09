using GoogleDriveAPI.DTOs;
using GoogleDriveAPI.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Drawing.Printing;
using System.Net.Http.Headers;

namespace GoogleDriveAPI.Pages
{
    public partial class FileSystem
    {
        private FileSystemModel file = new FileSystemModel();
        //private FileSystemDTO fileDto = new FileSystemDTO();
        private List<FileSystemModel> files = new();
        private MultipartFormDataContent content = new();
        //private async Task Save()
        //{
        //    if (file == null) return;
        //    fileDto = file.Change();
        //    _db.Add(fileDto);
        //    await _db.SaveChangesAsync();
        //}
        private async Task OnInputFileChanged(InputFileChangeEventArgs e)
        {
            var shouldRender = false;
            long maxFileSize = 1024 * 1500;
            var upload = false;
            // using var content = new MultipartFormDataContent();
            var file = e.GetMultipleFiles(1)[0];
            try
            {
                files.Add(new() { Name = file.Name });

                var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));

                fileContent.Headers.ContentType =
                    new MediaTypeHeaderValue(file.ContentType);

                content.Add(
                    content: fileContent,
                    name: "\"files\"",
                    fileName: file.Name);

                upload = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
