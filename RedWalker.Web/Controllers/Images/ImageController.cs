using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Images.Services;
using RedWalker.Core.Exceptions;

namespace RedWalker.Web.Controllers.Images;

[ApiController]
[Route("[controller]")]
public class ImageController: ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var image = await _imageService.GetByIdAsync(id);
        if (image == null)
        {
            throw new ValidationException("Изображение с указанным ID не найдено");
        }
        var tmp =  PhysicalFile(image.Path, "image/jpg");
        return tmp;
    }

}