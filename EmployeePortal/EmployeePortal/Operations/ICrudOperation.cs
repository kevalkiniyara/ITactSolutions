using EmployeePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Operations
{
    public interface ICrudOperation
    {
        void Create(EmployeeModel model);

        List<EmployeeModel> GetAllEmployees();

        EmployeeModel UpdateEmployee(EmployeeModel model);

        void DeleteEmployeeId(int id);

        EmployeeModel FindById(int id);

        void QueryMethod(EmployeeModel model,DepartmentModel model1,HumanResourceModel model2);
    }
}
