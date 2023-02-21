using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class TypeAccidentRepository : ITypeAccidentRepository
{
    private readonly RedWalkerContext _context;

    public TypeAccidentRepository(RedWalkerContext context)
    {
        _context = context;
    }
    /*private enum TypeAccident
    {
        HittingPedestrian, //Наезд на пешехода
        HittingСyclist, //Наезд на велосипедиста
        HittingWorker, //Наезд на лицо не являющееся участником дорожного движения, осуществляющего несение службы
        HittingMeansIndividualMobility //Наезд на средство индивидуальной мобильности (за исключением велосипеда)
    }

    private static readonly Dictionary<TypeAccident,string> DictTypeAccident = new(){
        {TypeAccident.HittingPedestrian,"Наезд на пешехода"},
        {TypeAccident.HittingСyclist,"Наезд на велосипедиста"},
        {TypeAccident.HittingWorker, "Наезд на рабочего"},
        {TypeAccident.HittingMeansIndividualMobility,"Наезд на лицо передвигающееся на СИМ"}
    };*/

    public Task<List<Directory>> GetAllAsync()
    {
        return _context.TypesAccident.Select(condition => new Directory
        {
            Id = condition.StringId,
            Name = condition.Name
        }).ToListAsync();
    }
    
    public async Task<Directory> GetByIdAsync(string id)
    {
        var type = await _context.TypesAccident.FirstOrDefaultAsync(condition => condition.StringId == id);
        if (type == null)
        {
            return null;
        }

        return new Directory
        {
            Id = type.StringId,
            Name = type.Name
        };
    }
    
}