using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using VKUNEWSAPPAPI.Data;
using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Data.Repository.Interface;
using VKUNEWSAPPAPI.Dto;
using VKUNEWSAPPAPI.Service.Interface;

namespace VKUNEWSAPPAPI.Controllers
{
    [Route("api/[controller]")]
  
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _repository;
        private readonly IAdminService _adminService;

        public AdminController(IUnitOfWork repository,
            IConfiguration configuration, IAdminService adminService)
        {
            _repository = repository;
            _configuration = configuration;
            _adminService = adminService;
        }

        [HttpGet("GetAdminList")]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdminList()
        {
            try
            {
                var result = await _adminService.GetAdminList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost("AddAdmin")]
        public async Task<IActionResult> AddAdmin([FromForm] AdminPhotoDto adminPhotoDto)
        {
            try
            {
                if (adminPhotoDto.File == null) return new UnsupportedMediaTypeResult();
                {
                    var response = await _adminService.AddAdmin(adminPhotoDto);
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
