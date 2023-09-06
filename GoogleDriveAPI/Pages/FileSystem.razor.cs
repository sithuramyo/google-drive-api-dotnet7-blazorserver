using GoogleDriveAPI.DTOs;
using GoogleDriveAPI.Models;
using System.Drawing.Printing;

namespace GoogleDriveAPI.Pages
{
    public partial class FileSystem
    {
        private FileSystemModel file = new FileSystemModel();
        private FileSystemDTO fileDto = new FileSystemDTO();
        protected override async Task OnInitializedAsync()
        {
         
        }
        private async Task Save()
        {
            if (file == null) return;
            fileDto = file.Change();
            _db.Add(fileDto);
            await _db.SaveChangesAsync();
        }
    }
}
