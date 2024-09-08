using CloudinaryDotNet.Actions;

namespace BlogModeling.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
        
        //Task<ImageUploadResult> UpdatePhotoAsync(IFormFile file);
        //Task<ImageUploadResult> UploadPhotoAsync(IFormFile file);
        //Task<ImageUploadResult> DeletePhotoAsync(IPhotoService photoService);
    }
}
