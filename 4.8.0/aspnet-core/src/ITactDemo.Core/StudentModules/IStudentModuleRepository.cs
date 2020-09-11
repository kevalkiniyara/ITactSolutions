using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using ITactDemo.StudentModules;
using System.Text;
using System.Threading.Tasks;

namespace ITactDemo.StudentModules
{
    public interface IStudentModuleRepository:IRepository<StudentModule>
    {
        Task CreateStudentModule(StudentModule input);
    }
}
