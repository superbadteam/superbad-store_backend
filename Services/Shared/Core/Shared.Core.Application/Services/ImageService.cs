using Microsoft.AspNetCore.Http;

namespace Shared.Core.Application.Services;

public class ImageService : IImageService
{
    public async Task<IEnumerable<string>> SaveAsync(IEnumerable<IFormFile> images)
    {
        var filePaths = new List<string>();

        var saveFileTasks = new List<Task>();

        foreach (var image in images)
        {
            var filePath = CreateImagePath(image);

            var stream = new FileStream(filePath, FileMode.Create);

            saveFileTasks.Add(image.CopyToAsync(stream));

            filePaths.Add(filePath);
        }

        await Task.WhenAll(saveFileTasks);

        return filePaths;
    }

    private static string CreateImagePath(IFormFile image)
    {
        var fileName =
            $"{Path.GetFileNameWithoutExtension(image.FileName)}-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}{Path.GetExtension(image.FileName)}";

        return Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
    }
}