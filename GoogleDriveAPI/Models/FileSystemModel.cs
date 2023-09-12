using GoogleDriveAPI.Utility;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GoogleDriveAPI.Models
{
    public class FileSystemModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string File { get; set; }
        public string? FileName { get => File?.ToUniqueName(); }

    }
}
