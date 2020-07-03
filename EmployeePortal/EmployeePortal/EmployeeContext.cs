using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }

        public DbSet<DepartmentModel> DepartmentModels { get; set; }

        public DbSet<HumanResourceModel> HumanResourceModels { get; set; }
    }
}
