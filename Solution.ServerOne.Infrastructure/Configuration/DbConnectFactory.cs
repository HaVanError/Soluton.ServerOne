using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Solution.ServerOne.Domain.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.ServerOne.Domain.Configuration
{
    public class DbConnectFactory : IDesignTimeDbContextFactory<DbConnect>
    {
        public DbConnect CreateDbContext(string[] args)
        {

            #region Ghi chú khi sử dụng class libr để connect db 
            // cài các công configuration 
            //using Microsoft.Extensions.Configuration;
            //using Microsoft.Extensions.Configuration.json;
            //và code như ở dưới sau đó nếu migration lỗi  "FileNotFoundException: The configuration file 'app.json' was not found and is not optional."
            // thì phải cấu hình lại trong .csproj
            #endregion
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("app.json", optional: false, reloadOnChange: true)
        .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DbConnect>();
            var connectionString = config.GetConnectionString("db");

            optionsBuilder.UseSqlServer(connectionString);

            return new DbConnect(optionsBuilder.Options);
        }
    }
}
