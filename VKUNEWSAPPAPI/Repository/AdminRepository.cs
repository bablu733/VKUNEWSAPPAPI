using  VKUNEWSAPPAPI.Data.Repository;
using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Data.Repository.Interface;

namespace VKUNEWSAPPAPI.Data.Repository
{
    public class AdminRepository: Repository<Admin>,IAdminRepository
    {
        public AdminRepository( VKUNEWSAPPAPIDbContext vKUNEWSAPPAPIDbContext):base(vKUNEWSAPPAPIDbContext) 
        {
        
        }
    }
}
