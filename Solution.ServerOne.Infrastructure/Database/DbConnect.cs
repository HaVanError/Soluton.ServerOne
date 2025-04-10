using Microsoft.EntityFrameworkCore;
using Solution.ServerOne.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Domain.Database
{
    public class DbConnect :DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Cấu hình bảng cho các bản
            #region Configuration Cho User theo FluentApi 
            builder.Entity<User>().HasKey(u => u.IdUser);
            builder.Entity<User>().Property(x=>x.Email).IsRequired();
            builder.Entity<User>().Property(x => x.Name).IsRequired();
            builder.Entity<User>().Property(x => x.Phone).IsRequired();
            builder.Entity<User>().Property(x => x.Password).IsRequired();
            #endregion
            #region Configuration Cho Role theo FluentApi 
            builder.Entity<Role>().HasKey(u => u.IdRole);
            builder.Entity<Role>().Property(x => x.NameRole).IsRequired();
            builder.Entity<Role>().Property(x => x.Description).IsRequired();

            #endregion

            // Cấu hình khóa ngoại cho các bảng

            #region User (N-1) Role
            builder.Entity<User>()
                .HasOne(x => x.Role)// 1 role có thể chứa nhiều User
                .WithMany(a => a.Users)
                .HasForeignKey(x => x.IdRole)// gán khóa ngoại là IdRole trong bảng User
                .OnDelete(DeleteBehavior.Restrict);// tránh xóa role lại xóa luôn user
            #endregion

            #region AutoAddRole
            builder.Entity<Role>().HasData(new Role { IdRole = 1,NameRole="Admin",Description="Người quản trị hệ thống có tất cả các quyền tối cao" });
            builder.Entity<Role>().HasData(new Role { IdRole = 2, NameRole = "User", Description = "Người dùng bình thường có thể xử dụng chức năng của website một cách bình thường" });
            #endregion



        }
    }
}
