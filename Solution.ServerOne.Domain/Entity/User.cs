using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Domain.Entity
{
    public class User
    {
        public int IdUser {  get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty ;
  
        public string Password { get; private set; } = string.Empty ;
 
        public string Phone {  get; private set; } = string.Empty ;
        public bool IsDeleted { get; set; } = false; // thuộc tính dùng cho soft delete. 

        public int IdRole { get; private set; }

        public Role? Role { get; private set; }
        
#region Phương thức tạo mới một User 
        public static User Create(string name, string email, string password, string phone, Role role)
        {
            // Kiểm tra đơn giản (có thể tách ra thành Validation sau)
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên không được để trống", nameof(name));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không hợp lệ", nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Mật khẩu không được để trống", nameof(password));

            if (role == null)
                throw new ArgumentNullException(nameof(role), "Vai trò không được null");

            // Có thể hash password ở tầng Application hoặc Service
            return new User
            {
                Name = name.Trim(),
                Email = email.Trim().ToLower(),
                Password = password, // Chú ý: Hash ở chỗ khác nha
                Phone = phone,
                IdRole = role.IdRole,
                Role = role
            };
        }
        #endregion
        #region Cập nhật User 
        public  void Update( string name , string email,string phone , string password , Role role )
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Không để trống Tên ");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email không hợp lệ", nameof(email));

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Mật khẩu không được để trống", nameof(password));
            
            if (string.IsNullOrWhiteSpace(phone))
                throw new ArgumentException("Mật khẩu không được để trống", nameof(phone));
                
            Name = name.Trim();
            Email = email.Trim().ToLower(); 
            Password = password;
            Role = role;
            IdRole = role.IdRole;
            Phone = phone;
        }
        #endregion
        #region Soft Delete User 
        public void DeleteUser()
        {
            IsDeleted = true;
           
        }
        #endregion
    }
}
