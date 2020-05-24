using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.Data
{
    public class EmpValidator: AbstractValidator<EmployeeInfo>
    {
        public EmpValidator()
        {
           RuleFor(emp=>emp.Name).NotEmpty().MaximumLength(50);
           RuleFor(emp => emp.City).NotEmpty().MaximumLength(50);
           RuleFor(emp => emp.Country).NotEmpty().WithMessage("You must enter the Country");
           RuleFor(emp => emp.Gender).NotEmpty();
        }
    }
}
