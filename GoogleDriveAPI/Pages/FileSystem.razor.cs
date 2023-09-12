using GoogleDriveAPI.DTOs;
using GoogleDriveAPI.GoogleDriveServices;
using GoogleDriveAPI.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Drawing.Printing;
using System.Net.Http.Headers;

namespace GoogleDriveAPI.Pages
{
    public partial class FileSystem
    {
        private FileSystemModel fileModel = new FileSystemModel();
        private FileSystemDTO fileDTO = new FileSystemDTO();
        private List<IBrowserFile> loadedFiles = new();

        private async Task Save()
        {
            try
            {
                foreach (var file in loadedFiles)
                {
                    fileModel.File = file.Name;
                }
                if (fileModel is null) return;
                fileDTO = fileModel.Change();
                _db.Add(fileDTO);
                await _db.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void LoadFiles(InputFileChangeEventArgs e)
        {
            loadedFiles.Clear();

            foreach (var file in e.GetMultipleFiles())
            {
                try
                {
                    loadedFiles.Add(file);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
