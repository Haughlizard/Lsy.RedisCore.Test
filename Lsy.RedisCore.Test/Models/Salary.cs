using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class Salary
    {
        public int EmpNo
        {
            get;set;
        }

        public int IntSalary
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

        public Employee Employee
        {
            get;set;
        }
    }
}
