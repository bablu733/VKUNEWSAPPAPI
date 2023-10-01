using VKUNEWSAPPAPI.Data.Models;
using VKUNEWSAPPAPI.Dto;

namespace VKUNEWSAPPAPI.Data.Repository.Interface
{
    public interface IUnitOfWork
    {
        IAdminRepository Admin { get; }
    }
}
