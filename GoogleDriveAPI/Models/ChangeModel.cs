using GoogleDriveAPI.DTOs;

namespace GoogleDriveAPI.Models
{
    public static class ChangeModel
    {
        public static FileSystemDTO? Change(this FileSystemModel model)
        {
            if (model == null) return null;
            return new FileSystemDTO
            {
                Id = model.Id,
                Name = model.Name,
                FileSystemName = model.FileSystemName
            };
        }
    }
}
