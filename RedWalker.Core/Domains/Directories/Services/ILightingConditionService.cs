﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Directories.Services;

public interface ILightingConditionService
{
    public  Task<List<Directory>> GetAllAsync();
    public  Task<Directory> GetByIdAsync(string id);
}