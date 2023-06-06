using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RedWalker.Core.Domains.Images.Services;
using RedWalker.Core.Exceptions;

namespace RedWalker.Web.Controllers.Images;

[ApiController]
[Route("[controller]")]
public class ImageController: ControllerBase
{
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService,IWebHostEnvironment hostEnvironment)
    {
        _imageService = imageService;
        _hostEnvironment = hostEnvironment;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var image = await _imageService.GetByIdAsync(id);
        if (image == null)
        {
            throw new ValidationException("Изображение с указанным ID не найдено");
        }
        var applicationPath = _hostEnvironment.ContentRootPath;
        var fullPath = Path.Combine(applicationPath, image.Path);
        return  PhysicalFile(fullPath, "image/png");
    }

}