using StackExchange.Redis;
using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Lsy.RedisCore.Test.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;

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

                //预加载导航属性
                var employee = myDb.Employees
                    .Include(p => p.Salaries)
                    .Single(p => p.EmpNo == 100001);

                var firstQuery = myDb.Employees
                    .Single(p => p.EmpNo == 10001);
                //显式加载导航属性,需设置 QueryTrackingBehavior.TrackAll
                myDb.Entry(firstQuery)
                    .Collection(p=>p.Salaries)
                    .Load();

                //还有一种懒加载

                //执行原始SQL
                var empNo = 100001;
                var query1 = myDb.Employees
                    .FromSqlRaw("select * from employees where emp_no = {0}", empNo).ToList();

                var query2 = myDb.Employees
                    .FromSqlInterpolated($"select * from employees where emp_no = {empNo}").ToList();

                var emp_no = new MySqlParameter("emp_no", 100001);
                var query3 = myDb.Employees
                    .FromSqlRaw($"select * from employees where emp_no = @emp_no", emp_no).ToList();
                sw.Stop();

                var jsonString = JsonConvert.SerializeObject(employee, null,
                    new JsonSerializerSettings() {
                        //循环引用不序列化
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
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
