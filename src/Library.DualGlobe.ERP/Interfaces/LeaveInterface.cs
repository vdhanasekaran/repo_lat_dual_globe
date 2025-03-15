using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class LeaveInterface
    {
        public static void Create(Leave leave)
        {
            using (var context = new ERPContext())
            {
                context.Entry(leave).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Leave[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Leaves.ToArray();
            }
        }

        public static Leave Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Leaves.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public static Leave ReadByEmployeeAndDate(int id, DateTime LeaveDate)
        {
            using (var context = new ERPContext())
            {
                return context.Leaves.Where(i => i.EmployeeId == id && i.StartDate <= LeaveDate && i.EndDate >= LeaveDate).FirstOrDefault();
            }
        }

        public static Leave[] ReadByEmployeeYearAndMonth(int empId, int year, int month)
        {
            using (var context = new ERPContext())
            {
                var conf = context.Leaves.Where(i => i.EmployeeId == empId).ToArray();
                return conf.Where(i => (i.StartDate.Value.Month == month && i.StartDate.Value.Year == year) ||
                                            (i.EndDate.Value.Month == month && i.EndDate.Value.Year == year)).ToArray();
            }
        }

        public static Leave[] ReadByYearAndMonth(int year, int month)
        {
            using (var context = new ERPContext())
            {
                return context.Leaves.Where(i => (i.StartDate.Value.Month == month && i.StartDate.Value.Year == year) ||
                (i.EndDate.Value.Month == month && i.EndDate.Value.Year == year)).ToArray();
            }
        }
        public static void Update(Leave leave)
        {
            using (var context = new ERPContext())
            {
                context.Entry(leave).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Leaves.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
