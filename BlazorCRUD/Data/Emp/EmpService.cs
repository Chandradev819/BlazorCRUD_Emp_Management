using BlazorCRUD.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlazorCRUD.Data
{
    public class EmpService : IEmpService
    {
        private readonly ApplicationDbContext _db;
        public EmpService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<EmployeeInfo> GetEmp()
        {
            //To avoid not fetching from Cache memeory
            var empList = _db.Emp.AsNoTracking().ToList();
            return empList;
        }
        public string Create(EmployeeInfo objEmp)
        {
            _db.Emp.Add(objEmp);
            _db.SaveChanges();
            return "Save Successfully";
        }

        public EmployeeInfo GetEmpById(int id)
        {
            EmployeeInfo employee = _db.Emp.AsNoTracking().FirstOrDefault(s => s.EmpId == id);
            return employee;
        }

        public string UpdateEmp(EmployeeInfo objEmpInfo)
        {
            _db.Emp.Update(objEmpInfo);
            _db.SaveChanges();
            return "Data has been updated";
        }
        public string DeleteEmp(EmployeeInfo objEmpInfo)
        {
            _db.Remove(objEmpInfo);
            _db.SaveChanges();
            return "Data has been deleted";
        }

        //For Custom Pagination
        public PaginatedEmpsViewModel<EmployeeInfo> GetEmpsPaginated(int pageSize = 10, int pageIndex = 0)
        {
            var emps = _db.Emp.AsNoTracking().ToList();

            var itemsOnPage = emps
                .OrderBy(c => c.EmpId)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            return new PaginatedEmpsViewModel<EmployeeInfo>(
                pageIndex, pageSize, emps.Count, itemsOnPage);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
