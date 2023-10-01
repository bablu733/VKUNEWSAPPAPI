using Microsoft.AspNetCore.Mvc;
using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Dto;

namespace VKUNEWSAPPAPI.Service.Interface
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAdminList();
        Task<Admin> AddAdmin(AdminPhotoDto adminPhotoDto);
    }
}
