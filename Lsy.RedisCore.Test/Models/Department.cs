using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class Department
    {
        public string DeptNo
        {
            get;set;
        }

        public string DeptName
        {
            get;set;
        }

        public ICollection<DeptManager> Managers
        {
            get;set;
        }

        public ICollection<DeptEmp> DeptEmployees
        {
            get; set;
        }
    }
}
