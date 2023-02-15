using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class TypeAccidentRepository : ITypeAccidentRepository
{
    public enum TypeAccident
    {
        HittingPedestrian, //Наезд на пешехода
        HittingСyclist, //Наезд на велосипедиста
        HittingWorker, //Наезд на лицо не являющееся участником дорожного движения, осуществляющего несение службы
        HittingMeansIndividualMobility, //Наезд на средство индивидуальной мобильности (за исключением велосипеда)
        Other //Не связан ни с пешеходом ни с велосипедистом
    }

    public static readonly Dictionary<TypeAccident,string> DictTypeAccident = new(){
        {TypeAccident.HittingPedestrian,"Наезд на пешехода"},
        {TypeAccident.HittingСyclist,"Наезд на велосипедиста"},
        {TypeAccident.HittingWorker, "Наезд на рабочего"},
        {TypeAccident.HittingMeansIndividualMobility,"Наезд на лицо передвигающееся на СИМ"}
    };

    public List<Directory> GetAll()
    {
        return DictTypeAccident.Select(dict => new Directory
        {
            Id = dict.Key.ToString(),
            Name = dict.Value
        }).ToList();
    }
    
    public Directory GetById(string id)
    {
        if (!Enum.TryParse(id, out TypeAccident key))
        {
            return null;
        }
        if (!DictTypeAccident.TryGetValue(key, out var typeAccident))
        {
            return null;
        }

        return new Directory
        {
            Id = id,
            Name = typeAccident.ToString()
        };
    }
    
}