using Izeem.DAL.IRepositories;
using Izeem.Domain.Entities.Assets;
using Izeem.Service.Commons.Helpers;
using Izeem.Service.DTOs.Assets;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Assets;
using Microsoft.AspNetCore.Http;

namespace Izeem.Service.Services.Assets;

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AssetService(IRepository<Asset> repository, IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Asset> UploadAsync(AssetCreationDto dto)
    {
        var webRootPath = Path.Combine(PathHelper.WebRootPath);

        if (!Directory.Exists(webRootPath))
            Directory.CreateDirectory(webRootPath);

        var fileExtention = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtention}";
        var filePath = Path.Combine(webRootPath, fileName);

        var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());
        await dto.FormFile.CopyToAsync(fileStream);

        var imageUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}/{fileName}";

        var asset = new Asset()
        {
            FileName = fileName,
            FilePath = imageUrl,
        };

        await _repository.AddAsync(asset);
        await _repository.SaveAsync();
        return asset;
    }

    public async Task<bool> RemoveAsync(Asset assetment)
    {
        if (assetment is null)
            return false;

        var existAssetment = await _repository.SelectAsync(a => a.Id.Equals(assetment.Id));
        if (existAssetment is null)
            return false;

        _repository.Delete(existAssetment);
        var result = await _repository.SaveAsync();
        return true;
    }
}

