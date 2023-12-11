using Microsoft.AspNetCore.Http;

namespace Izeem.Service.DTOs.Assets;

public class AssetCreationDto
{
    public IFormFile FormFile { get; set; }
}
