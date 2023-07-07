using System;
using System.Collections.Generic;
using StarbucksDatabase.Models;
using System.Data;
using Dapper;

namespace StarbucksDatabase
{
    public class EmployeesRepository : IEmployeesRepository

    {
        private readonly IDbConnection _conn;

        public EmployeesRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Employees> GetAllEmployees()
        {
            return _conn.Query<Employees>("SELECT * FROM Employees;");
        }
        public Employees GetEmployee(int id)
        {
            return _conn.QuerySingle<Employees>("SELECT * FROM Employees WHERE EmployeeID = @id", new { id = id });
        }
        public void UpdateEmployees(Employees employees)
        {
            _conn.Execute("UPDATE employees SET EmployeeName = @name, EmployeePosition = @position, EmployeeStore = @store WHERE EmployeeID = @id",
             new { name = employees.EmployeeName, position = employees.EmployeePosition, id = employees.EmployeeID, store = employees.EmployeeStore });
        }
        public void InsertEmployees(Employees EmployeesToEmployees)
        {
            _conn.Execute("INSERT INTO Employees (EmployeeID, EmployeeName, EmployeePosition, EmployeeStore) VALUES (@id, @name, @position, @store);",
                new { id = EmployeesToEmployees.EmployeeID, name = EmployeesToEmployees.EmployeeName, position = EmployeesToEmployees.EmployeePosition, store = EmployeesToEmployees.EmployeeStore });


        }
        public void DeleteEmployees(Employees Employee)
        {
            _conn.Execute("DELETE FROM Employees WHERE EmployeeID = @id;", new { id = Employee.EmployeeID });

        }
         

    }
}
