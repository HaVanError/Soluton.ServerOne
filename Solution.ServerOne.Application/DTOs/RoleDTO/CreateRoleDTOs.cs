using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Application.DTOs.RoleDTO
{
    public class CreateRoleDTOs
    {
       // public int IdRole { get; set; }
        public string NameRole { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
