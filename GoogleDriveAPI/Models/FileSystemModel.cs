using GoogleDriveAPI.Utility;

namespace GoogleDriveAPI.Models
{
    public class FileSystemModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? FileSystem { get; set; }
        public string? FileSystemName { get => FileSystem?.FileName.ToUniqueName(); }
    }
}
