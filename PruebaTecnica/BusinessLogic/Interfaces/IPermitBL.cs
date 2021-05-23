using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface IPermitBL
    {
        List<Permit> PermissionList();
        Permit PermissionById(int id);
        void SavePermission(Permit permit);
        void UpdatePermission(Permit permit);
        bool DeletePermission(int id);
    }
}
