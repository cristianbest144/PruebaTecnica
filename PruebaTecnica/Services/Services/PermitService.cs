using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PermitService : IPermitService
    {
        private readonly AplicationDbContext _context;

        public PermitService(AplicationDbContext context)
        {
            _context = context;
        }

        public List<Permit> PermissionList()
        {
            return _context.Permit.Select(x => new Permit()
            {
                Id = x.Id,
                EmployeeName = x.EmployeeName,
                LastNameEmployee = x.LastNameEmployee,
                IdPermitType = x.IdPermitType,
                PermitDateFormat = x.PermitDate.ToString("dd/MM/yyyy"),
                PermitType = x.PermitType,
            }).ToList();
        }

        public Permit PermissionById(int id)
        {
            return _context.Permit.Select(x => new Permit()
            {
                Id = x.Id,
                EmployeeName = x.EmployeeName,
                LastNameEmployee = x.LastNameEmployee,
                IdPermitType = x.IdPermitType,
                PermitDateFormat = x.PermitDate.ToString("yyyy-MM-dd"),
                PermitType = x.PermitType,
            }).FirstOrDefault(x => x.Id == id);
        }

        public void SavePermission(Permit permit)
        {
            _context.Permit.Add(permit);
            _context.SaveChanges();
        }

        public void UpdatePermission(Permit permit)
        {
            _context.Entry(permit).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool DeletePermission(int id)
        {
            Permit permit = _context.Permit.Find(id);

            if (permit == null)
            {
                return false;
            }

            _context.Permit.Remove(permit);
            _context.SaveChanges();

            return true;
        }
    }
}
