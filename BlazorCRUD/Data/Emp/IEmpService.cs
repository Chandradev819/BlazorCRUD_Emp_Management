using BlazorCRUD.ViewModel;
using System;
using System.Collections.Generic;

namespace BlazorCRUD.Data
{
    public interface IEmpService: IDisposable
    {
        string Create(EmployeeInfo objEmp);
        string DeleteEmp(EmployeeInfo objEmpInfo);
        List<EmployeeInfo> GetEmp();
        EmployeeInfo GetEmpById(int id);
        PaginatedEmpsViewModel<EmployeeInfo> GetEmpsPaginated(int pageSize = 10, int pageIndex = 0);
        string UpdateEmp(EmployeeInfo objEmpInfo);
    }
}