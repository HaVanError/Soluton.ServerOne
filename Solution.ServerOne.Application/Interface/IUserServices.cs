using Solution.ServerOne.Application.DTOs.RoleDTO;
using Solution.ServerOne.Application.DTOs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Application.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<RoleViewModel>> GetAllAsync();
      //  Task<UserDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateRoleDTOs user);
    }
}
