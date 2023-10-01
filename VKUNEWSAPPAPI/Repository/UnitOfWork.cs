using VKUNEWSAPPAPI.Data;
using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Data.Repository;
using VKUNEWSAPPAPI.Data.Repository.Interface;
using static System.Net.Mime.MediaTypeNames;

namespace VkuNewsApp.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly VKUNEWSAPPAPIDbContext _vkuContext;
    
    private IAdminRepository? _adminrepository;
   

    private readonly IDisposable _dbdispose;
    private readonly DbFactory _dbFactory;
 
    public UnitOfWork(VKUNEWSAPPAPIDbContext vkuContext)
    {
        _vkuContext = vkuContext;
    }
    public IAdminRepository Admin
    {
        get { return _adminrepository ??= new AdminRepository(_vkuContext); }
    }


}
