using Microsoft.AspNetCore.Identity;
using VKUNEWSAPPAPI.Data;
using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Data.Repository.Interface;
using VKUNEWSAPPAPI.Dto;
using VKUNEWSAPPAPI.Helper.Exceptions;
using VKUNEWSAPPAPI.Service.Interface;

namespace VKUNEWSAPPAPI.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _repository;
        private readonly VKUNEWSAPPAPIDbContext _dbContext;


        public AdminService(IUnitOfWork repository, VKUNEWSAPPAPIDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }
        public async Task<List<Admin>> GetAdminList()
        {
            try
            {
                var Admin = await _repository.Admin.FindAllAsync();
                var result = Admin.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Admin> AddAdmin(AdminPhotoDto adminPhotoDto)
        {
            try
            {

                using (var memoryStream = new MemoryStream())
                {
                    await adminPhotoDto.File.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    var base64String = Convert.ToBase64String(imageBytes);

                    Admin newAdmin = new Admin()
                    {
                        Name = adminPhotoDto.Name,
                        Gender = adminPhotoDto.Gender,
                        BloodGroup = adminPhotoDto.BloodGroup,
                        DateOfBirth = adminPhotoDto.DateOfBirth,
                        Age = adminPhotoDto.Age,
                        FatherName = adminPhotoDto.FatherName,
                        MotherName = adminPhotoDto.MotherName,
                        FatherKula = adminPhotoDto.FatherKula,
                        MotherKula = adminPhotoDto.MotherKula,
                        Education = adminPhotoDto.Education,
                        MyCast = adminPhotoDto.MyCast,
                        Employment = adminPhotoDto.Employment,
                        Marriage = adminPhotoDto.Marriage,
                        State = adminPhotoDto.State,
                        District = adminPhotoDto.District,
                        Taluk = adminPhotoDto.Taluk,
                        Hobli= adminPhotoDto.Hobli,
                        Village = adminPhotoDto.Village,
                        PinCode = adminPhotoDto.PinCode,
                        God= adminPhotoDto.God,
                        Place = adminPhotoDto.Place,
                        GodTaluk= adminPhotoDto.GodTaluk,
                        Goddesses = adminPhotoDto.Goddesses,
                        GoddessesPlace= adminPhotoDto.GoddessesPlace,
                        GoddessesTaluk=adminPhotoDto.GoddessesTaluk,
                        Photo=base64String,
                        AadharNumber = adminPhotoDto.AadharNumber,
                        MobileNumber = adminPhotoDto.MobileNumber,
                        Otp = adminPhotoDto.Otp,
                    };

                    _dbContext.Admin.Add(newAdmin);
                    await _dbContext.SaveChangesAsync();

                    return newAdmin;
                }
            }
            catch (Exception ex)
            {
                throw new CustomException("An error occurred while adding the admin.");
            }
        }


    }
}
