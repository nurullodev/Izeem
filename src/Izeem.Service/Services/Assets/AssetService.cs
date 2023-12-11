using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Assets;
using Izeem.Service.Commons.Helpers;
using Izeem.Service.DTOs.Assets;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Assets;

namespace Izeem.Service.Services.Assets;

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> _repository;
    public AssetService(IRepository<Asset> repository)
    {
        _repository = repository;
    }

    public async Task<Asset> UploadAsync(AssetCreationDto dto)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, "Files");

        if (!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createdAsset = new Asset
        {
            FileName = fileName,
            FilePath = fullPath
        };
        await _repository.AddAsync(createdAsset);
        await _repository.SaveAsync();

        return createdAsset;
    }

    public async Task<bool> RemoveAsync(Asset Asset)
    {
        _repository.Delete(Asset);
        await _repository.SaveAsync();
        return true;
    }
}

