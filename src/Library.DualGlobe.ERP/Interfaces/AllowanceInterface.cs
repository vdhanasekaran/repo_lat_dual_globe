using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class AllowanceInterface
    {
        public static void Create(Allowance allowance)
        {
            using (var context = new ERPContext())
            {
                context.Entry(allowance).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Allowance[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Allowances
                              .Include(t => t.employee).ToArray();
            }
        }

        public static Allowance[] ReadByMonth(DateTime allowanceMonth)
        {
            using (var context = new ERPContext())
            {
                return context.Allowances.Where(t => t.AllowanceDate.Month == allowanceMonth.Month && 
                                                t.AllowanceDate.Year == allowanceMonth.Year)
                               .Include(t => t.employee).ToArray();
            }
        }

        public static Allowance[] ReadByEmployeeMonthYear(int empId, int month,int year)
        {
            using (var context = new ERPContext())
            {
                return context.Allowances.Where(t => t.AllowanceDate.Month == month 
                                                && t.AllowanceDate.Year == year
                                                & t.EmployeeId == empId).ToArray();
                               
            }
        }

        public static Allowance Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Allowances.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public static void Update(Allowance allowance)
        {
            using (var context = new ERPContext())
            {
                context.Entry(allowance).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Allowances.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
