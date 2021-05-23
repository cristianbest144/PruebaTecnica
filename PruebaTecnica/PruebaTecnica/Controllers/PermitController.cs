using BusinessLogic.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitController : ControllerBase
    {
        private readonly IPermitBL _permitBL;

        public PermitController(IPermitBL permitBL)
        {
            _permitBL = permitBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var permissionList = _permitBL.PermissionList();
                return Ok(permissionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var permission = _permitBL.PermissionById(id);
                return Ok(permission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Permit permit)
        {
            try
            {
                _permitBL.SavePermission(permit);
                return Ok(new { message = "Se guardó el permiso con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Permit permit)
        {
            try
            {
                if (id != permit.Id)
                {
                    return NotFound();
                }

                _permitBL.UpdatePermission(permit);
                return Ok(new { message = "El permiso fue actualizadó con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var response =_permitBL.DeletePermission(id);
                return Ok(new { response });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
