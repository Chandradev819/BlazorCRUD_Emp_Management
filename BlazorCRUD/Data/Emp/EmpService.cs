using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmpService
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
    }
}
