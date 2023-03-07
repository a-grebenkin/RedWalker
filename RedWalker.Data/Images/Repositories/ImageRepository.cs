using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Images;
using RedWalker.Core.Domains.Images.Repositories;

namespace RedWalker.Data.Images.Repositories;

public class ImageRepository:IImageRepository
{
    private readonly RedWalkerContext _context;

    public ImageRepository(RedWalkerContext context)
    {
        _context = context;
    }
    public async Task<Image> GetByIdAsync(string id)
    {
        var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);
        if (image == null)
        {
            return null;
        }
        return new Image
        {
            Id = "Test",
            Path = image.Path,
        };
    }
}