using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPermitService
    {
        List<Permit> PermissionList();
        Permit PermissionById(int id);
        void SavePermission(Permit permit);
        void UpdatePermission(Permit permit);
        bool DeletePermission(int id);
    }
}
