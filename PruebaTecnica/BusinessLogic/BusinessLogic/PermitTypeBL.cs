using BusinessLogic.Interfaces;
using Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.BusinessLogic
{
    public class PermitTypeBL : IPermitTypeBL
    {
        private readonly IPermitTypeService _permitTypeService;

        public PermitTypeBL(IPermitTypeService permitTypeService)
        {
            _permitTypeService = permitTypeService;
        }

        public List<PermitType> PermitTypeList()
        {
            return _permitTypeService.PermitTypeList();
        }
    }
}
