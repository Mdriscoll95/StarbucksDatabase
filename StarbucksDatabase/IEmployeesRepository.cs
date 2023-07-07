using System;
using System.Collections.Generic;
using StarbucksDatabase.Models;

namespace StarbucksDatabase 
{
    public interface IEmployeesRepository
    {
        public IEnumerable<Employees> GetAllEmployees();
        public Employees GetEmployee(int id);
        public void UpdateEmployees(Employees employee);
        public void InsertEmployees(Employees EmployeesToInsert);
        public void DeleteEmployees(Employees employee);

    }
}


