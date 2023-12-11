using Izeem.Domain.Entities.Assets;
using Izeem.Service.DTOs.Assets;

namespace Izeem.Service.Interfaces.Assets;

public interface IAssetService
{
    Task<Asset> UploadAsync(AssetCreationDto dto);
    Task<bool> RemoveAsync(Asset Asset);
}