using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class EmployeeInterface
    {
        public static void Create(Employee employee)
        {
            using (var context = new ERPContext())
            {
                context.Entry(employee).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Employees.Count();
            }
        }

        public static Employee[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Employees.Where(t => t.Status == "true")
                              //.Include(t => t.EmployeeDocuments)
                              .ToArray();
            }
        }

        public static Employee[] ReadByWorkStatus(string workStatus)
        {
            using (var context = new ERPContext())
            {
                return context.Employees.Where(t => t.WorkStatus == workStatus).ToArray();
            }
        }

        public static List<Employee> ReadByWorkStatus()
        {
            using (var context = new ERPContext())
            {
                return context.Employees.Where(t => t.WorkStatus == "SingaporeCitizen" || t.WorkStatus == "SingaporePR").ToList();
            }
        }

        public static Employee[] ReadAll()
        {
            using (var context = new ERPContext())
            {
                return context.Employees
                              .Include(x => x.allowance)
                              .Include(x => x.loanAndAdvance)
                              .Include(x => x.timesheet)
                              .Include(x => x.salaryDetail)
                              .Include(t => t.EmployeeDocuments)
                              .ToArray();
            }
        }

        public static Employee Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Employees.Where(t => t.Id == id)
                              .Include(x => x.allowance)
                              .Include(x => x.loanAndAdvance)
                              .Include(x => x.timesheet)                              
                              .Include(x => x.salaryDetail)
                              .Include(t => t.EmployeeDocuments)
                              .FirstOrDefault();
            }
        }

        public static Employee ReadByEmpId(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Employees.Where(t => t.Id == id).Include(t => t.EmployeeDocuments).FirstOrDefault();

            }
        }


        public static void Update(Employee employee)
        {
            using (var context = new ERPContext())
            {
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static object ReadByEmployeeStatus(string employeeStatus)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var empRecord = context.Employees.Find(id);
                context.Entry(empRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void DeleteDocument(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Employees.SelectMany(t => t.EmployeeDocuments);
                var document = data.Where(j => j.Id == id).FirstOrDefault();
                context.Entry(document).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void InsertDocument(EmployeeDocument record, Employee parent)
        {
            using (var context = new ERPContext())
            {
                record.Employee = parent;
                context.Entry(parent).State = EntityState.Unchanged;
                context.Entry(record).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
