using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class PublicHolidayInterface
    {
        public static void Create(PublicHoliday publicHoliday)
        {
            using (var context = new ERPContext())
            {
                context.Entry(publicHoliday).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static PublicHoliday[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.PublicHolidays.ToArray();
            }
        }

        public static PublicHoliday[] ReadByYear(int year)
        {
            using (var context = new ERPContext())
            {
                return context.PublicHolidays.Where(i => i.Date.Year == year).ToArray();
            }
        }

        public static PublicHoliday[] ReadByMonthYear(int month, int year)
        {
            using (var context = new ERPContext())
            {
                return context.PublicHolidays.Where(i => i.Date.Year == year && i.Date.Month == month).ToArray();
            }
        }

        public static PublicHoliday ReadByDate(DateTime date)
        {
            using (var context = new ERPContext())
            {
                return context.PublicHolidays.Where(t => t.Date == date).FirstOrDefault();
            }
        }

        public static void Update(PublicHoliday publicHoliday)
        {
            using (var context = new ERPContext())
            {
                context.Entry(publicHoliday).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.PublicHolidays.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
