using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Shared.Core.Application.Services;

namespace Shared.Infrastructure.Cloudinary;

public class CloudinaryCloudStorageService : ICloudStorageService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;
    private readonly IFileSystemService _fileSystemService;
    private readonly string _saveLocation;

    public CloudinaryCloudStorageService(CloudinaryDotNet.Cloudinary cloudinary, IFileSystemService fileSystemService,
        string saveLocation)
    {
        _cloudinary = cloudinary;
        _fileSystemService = fileSystemService;
        _saveLocation = saveLocation;
    }


    public async Task<string> UploadAsync(string imagePath)
    {
        var cloudImage = new ImageUploadParams
        {
            File = new FileDescription(imagePath),
            Folder = _saveLocation
        };

        var uploadResult = await _cloudinary.UploadAsync(cloudImage);

        _fileSystemService.DeleteFile(imagePath);

        if (uploadResult.Error != null) throw new Exception(uploadResult.Error.Message);

        return uploadResult.Url.ToString();
    }

    public async Task<IEnumerable<string>> UploadAsync(IEnumerable<string> imagePaths)
    {
        imagePaths = imagePaths.ToList();

        try
        {
            var uploadTasks = imagePaths.Select(imagePath => UploadAsync(imagePath)).ToList();

            await Task.WhenAll(uploadTasks);

            return uploadTasks.Select(task => task.Result);
        }
        catch (Exception)
        {
            _fileSystemService.DeleteFiles(imagePaths);
            throw;
        }
    }
}