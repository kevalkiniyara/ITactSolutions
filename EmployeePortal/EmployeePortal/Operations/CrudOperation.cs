using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeePortal.Models;

namespace EmployeePortal.Operations
{
    public class CrudOperation : ICrudOperation
    {
        private readonly EmployeeContext _context;

        public CrudOperation(EmployeeContext context)
        {
            _context = context;
        }

        public void Create(EmployeeModel model)
        {
            var employeeDetail = _context.EmployeeModels.Add(model);
            _context.SaveChanges();
        }

        public void DeleteEmployeeId(int id)
        {
            var employeeId = _context.EmployeeModels.Where(id1 => id1.EmployeeId == id).FirstOrDefault();
            _context.EmployeeModels.Remove(employeeId);
            _context.SaveChanges();
        }

        public EmployeeModel FindById(int id)
        {
            var employee = _context.EmployeeModels.Find(id);
            return employee;
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            var employees = _context.EmployeeModels.ToList();
            return employees;
        }

        public EmployeeModel UpdateEmployee(EmployeeModel model)
        {
            var employeeId = _context.EmployeeModels.Where(id => id.EmployeeId == model.EmployeeId).First();
            if(employeeId!=null)
            {
                employeeId.EmployeeName = model.EmployeeName;
                employeeId.EmployeeAddress = model.EmployeeAddress;
                employeeId.MobileNumber = model.MobileNumber;
                employeeId.BirthDate = model.BirthDate;
            }
            _context.SaveChanges();
            return employeeId;
        }
        public void QueryMethod(EmployeeModel model,DepartmentModel model1,HumanResourceModel model2)
        {
            var query1 = from e in _context.EmployeeModels
                         where e.EmployeeName == model.EmployeeName
                         select e;
            var query2 = _context.EmployeeModels.Where(e => e.EmployeeName ==model.EmployeeName).First();

            var query3 = from e1 in _context.EmployeeModels.OfType<object>()
                         select e1;
            var query4 = from e2 in _context.EmployeeModels
                         where e2.EmployeeName == model.EmployeeName
                         orderby e2.EmployeeName ascending
                         select e2;
            var query5 = _context.EmployeeModels.OrderBy(e => e.EmployeeName);

            var query6 = _context.EmployeeModels.OrderBy(e => e.EmployeeName).ThenBy(e=>e.BirthDate);

            var query7 = from e3 in _context.EmployeeModels
                         where e3.EmployeeName == model.EmployeeName
                         group e3 by e3.EmployeeAddress;
            var query8 = _context.EmployeeModels.GroupBy(e => e.EmployeeAddress);
        }
    }
}
