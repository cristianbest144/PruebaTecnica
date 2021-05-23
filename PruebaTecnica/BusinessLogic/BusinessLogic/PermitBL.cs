using BusinessLogic.Interfaces;
using Entities;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class PermitBL : IPermitBL
    {
        private readonly IPermitService _permitService;

        public PermitBL(IPermitService permitService)
        {
            _permitService = permitService;
        }

        public List<Permit> PermissionList()
        {
            return _permitService.PermissionList();
        }

        public Permit PermissionById(int id)
        {
            return _permitService.PermissionById(id);
        }

        public void SavePermission(Permit permit)
        {
            _permitService.SavePermission(permit);
        }

        public void UpdatePermission(Permit permit)
        {
            _permitService.UpdatePermission(permit);
        }

        public bool DeletePermission(int id)
        {
            return _permitService.DeletePermission(id);
        }
    }
}
