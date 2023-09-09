using System.ComponentModel.DataAnnotations.Schema;

namespace GoogleDriveAPI.DTOs
{
    [Table("Tbl_File")]
    public class FileSystemDTO
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string FileSystemName { get; set; }
    }
}
