using Entities;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PermitTypeService : IPermitTypeService
    {
        private readonly AplicationDbContext _context;

        public PermitTypeService(AplicationDbContext context)
        {
            _context = context;
        }

        public List<PermitType> PermitTypeList()
        {
            return _context.PermitType.ToList();
        }
    }
}
