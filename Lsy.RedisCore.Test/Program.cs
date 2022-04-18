using StackExchange.Redis;
using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Lsy.RedisCore.Test.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lsy.RedisCore.Test
{
    class Program
    {
        private static readonly string _connString = "Server=127.0.0.1;Database=employees;Uid=root;Pwd=root;";
        static void Main(string[] args)
        {
            using (EmployeesContext myDb = new EmployeesContext(_connString))
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var firstQuery = myDb.Employees.Include(p=>p.Salaries)
                    .Where<Employee>(p => p.EmpNo == 10001)
                    .FirstOrDefault()
                    .Salaries;
                var result = firstQuery.ToList();
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }

            #region
            //ConfigurationOptions options = new ConfigurationOptions()
            //{
            //    ClientName = "Lsy",
            //    Password = "12345678lsy",
            //    ConnectTimeout = 0,
            //    DefaultDatabase = 8,
            //    AbortOnConnectFail = false,
            //};

            //options.get_EndPoints().Add("127.0.0.1", 6379);

            //ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options);
            //var db = redis.GetDatabase(8);
            //var trans = db.CreateTransaction();


            //while (reader.Read())
            //{

            //    List<HashEntry> list = new List<HashEntry>();
            //    list.Add(new HashEntry("emp_no", reader.GetInt32("emp_no")));
            //    list.Add(new HashEntry("salary", reader.GetInt32("salary")));
            //    list.Add(new HashEntry("from_date", reader.GetString("from_date")));
            //    list.Add(new HashEntry("to_date", reader.GetString("to_date")));
            //    db.HashSet(new RedisKey($"{reader.GetString("emp_no")}-{DateTime.Parse(reader.GetString("from_date")).ToString("yyyy-MM-dd")}"), list.ToArray());
            //}
            //trans.Execute();





            //var fieldEntry = db.HashGet("10001","birth_date");
            //var entries = db.HashGetAll("10001");
            #endregion

            Console.ReadKey();
           
        }
    }
}
