using Microsoft.AspNetCore.Http;

namespace Izeem.Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}
