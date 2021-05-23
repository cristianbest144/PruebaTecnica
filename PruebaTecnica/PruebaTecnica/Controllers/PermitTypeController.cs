using BusinessLogic.Interfaces;
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
    public class PermitTypeController : ControllerBase
    {
        private readonly IPermitTypeBL _permitTypeBL;

        public PermitTypeController(IPermitTypeBL permitTypeBL)
        {
            _permitTypeBL = permitTypeBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var permissionList = _permitTypeBL.PermitTypeList();
                return Ok(permissionList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
