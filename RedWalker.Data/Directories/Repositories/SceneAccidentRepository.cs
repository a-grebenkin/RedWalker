using System;
using System.Collections.Generic;
using System.Linq;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class SceneAccidentRepository : ISceneAccidentRepository
{
     private enum SceneAccident
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
     };
    public List<Directory> GetAll()
    {
        return DictSceneAccident.Select(dict => new Directory
        {
            Id = dict.Key.ToString(),
            Name = dict.Value
        }).ToList();
    }

    public Directory GetById(string id)
    {
        if (!Enum.TryParse(id, out SceneAccident key))
        {
            return null;
        }
        if (!DictSceneAccident.TryGetValue(key, out var typeAccident))
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