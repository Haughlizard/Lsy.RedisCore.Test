using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class DeptManager
    {
        public string DeptNo
        {
            get;set;
        }

        public int EmpNo
        {
            get;set;
        }

        public DateTime FromDate
        {
            get;set;
        }

        public DateTime ToDate
        {
            get;set;
        }

        public Department Department
        {
            get;set;
        }

        public Employee Employee
        {
            get;set;
        }
    }
}
