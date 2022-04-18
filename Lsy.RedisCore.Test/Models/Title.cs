using System;
using System.Collections.Generic;
using System.Text;

namespace Lsy.RedisCore.Test.Models
{
    class Title
    {
        public int EmpNo
        {
            get; set;
        }

        public string Ttitle
        {
            get;set;
        }

        public DateTime FromDate
        {
            get; set;
        }

        public DateTime ToDate
        {
            get; set;
        }

        public Employee Employee
        {
            get;set;
        }
    }
}
