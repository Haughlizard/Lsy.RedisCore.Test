using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    public enum Gender
    {
        M,
        F
    }
    class Employee
    {
        public int EmpNo
        {
            get;set;
        }

        public DateTime BirthDate
        {
            get;set;
        }

        public string FirstName
        {
            get;set;
        }

        public string LastName
        {
            get;set;
        }

        public Gender Gender
        {
            get;set;
        }

        public DateTime HireDate
        {
            get;set;
        }

        public ICollection<DeptManager> Managers
        {
            get; set;
        }

        public ICollection<DeptEmp> DeptEmployees
        {
            get;set;
        }

        public ICollection<Salary> Salaries
        {
            get;set;
        }

        public ICollection<Title> Titles
        {
            get;set;
        }
    }
}
