using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ITactDemo.Authorization.Roles;
using ITactDemo.Authorization.Users;
using ITactDemo.MultiTenancy;
using ITactDemo.Students;
using ITactDemo.StudentHobbies;
using ITactDemo.Addresses;
using ITactDemo.Customers;
using ITactDemo.CustomerProducts;
using ITactDemo.Products;
using ITactDemo.Items;
using ITactDemo.Orders;
using ITactDemo.OrderItems;
using ITactDemo.Categories;
using ITactDemo.Employees;
using ITactDemo.EmployeeItems;
using ITactDemo.EmployeeHobbies;
using ITactDemo.ItemTables;
using ITactDemo.StudentModules;

namespace ITactDemo.EntityFrameworkCore
{
    public class ITactDemoDbContext : AbpZeroDbContext<Tenant, Role, User, ITactDemoDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ITactDemoDbContext(DbContextOptions<ITactDemoDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Student> Students { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<StudentHobby> StudentHobbies { get; set; }

        public DbSet<Country> countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeItem> EmployeeItems { get; set; }

        public DbSet<EmployeeHobby> EmployeeHobbies { get; set; }

        public DbSet<ItemTable> ItemTables { get; set; }

        public DbSet<StudentModule> StudentModules { get; set; }
    }
}
