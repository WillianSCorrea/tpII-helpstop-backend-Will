using HelpApp.Application.DTOs;
using HelpApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HelpApp.Application.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetById(int? id);
        Task Add(CategoryDTO category);

        Task Update(CategoryDTO category);

        Task Remove(int? id);
    }
}
