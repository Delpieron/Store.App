using Store.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.App.Services
{
    public interface ICategoriesService
    {
        Task<ICollection<CategoryViewModel>> GetAllAsync();
        
    }
}