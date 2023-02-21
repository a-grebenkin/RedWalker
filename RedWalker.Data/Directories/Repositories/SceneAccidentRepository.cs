using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class SceneAccidentRepository : ISceneAccidentRepository
{
    private readonly RedWalkerContext _context;

    public SceneAccidentRepository(RedWalkerContext context)
    {
        _context = context;
    }
     /*private enum SceneAccident
        {
            RegulatedCrosswalk, //регулируемый пешеходный переход
            UnregulatedCrosswalk, //нерегулируемый пешеходный переход
            BusStop, //остановка общественного транспорта
            TramStop, //остановка трамвая
            RegulatedCrossroad, //регулиремый перекресток
            UnregulatedCrossroad, //нерегулиремый перекресток
            Road //дорога
        }

     private static readonly Dictionary<SceneAccident, string> DictSceneAccident = new(){
            {SceneAccident.RegulatedCrosswalk, "Регулируемый пешеходный переход"},
            {SceneAccident.UnregulatedCrosswalk, "Нерегулируемый пешеходный переход"},
            {SceneAccident.BusStop, "Остановка общественного транспорта"},
            {SceneAccident.TramStop, "Остановка трамвая"},
            {SceneAccident.RegulatedCrossroad, "Регулиремый перекресток"},
            {SceneAccident.UnregulatedCrossroad, "Нерегулиремый перекресток"},
            {SceneAccident.Road, "Дорога"}
     };*/
    public Task<List<Directory>> GetAllAsync()
    {
        return _context.SceneAccidents.Select(condition => new Directory
        {
            Id = condition.StringId,
            Name = condition.Name
        }).ToListAsync();
    }

    public async Task<Directory> GetByIdAsync(string id)
    {
        var scene = await _context.SceneAccidents.FirstOrDefaultAsync(condition => condition.StringId == id);
        if (scene == null)
        {
            return null;
        }

        return new Directory
        {
            Id = scene.StringId,
            Name = scene.Name
        };
    }
}