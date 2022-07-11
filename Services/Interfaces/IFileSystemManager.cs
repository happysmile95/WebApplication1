﻿using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IFileSystemManager
    {
        Task<DepartamentFileInfo> GetDepartamentFileInfo();
        Task SaveDepartamentFileInfo(DepartamentFileInfo departmentFileInfo);
    }
}
