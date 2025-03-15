using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class PublicHolidayPayInterface
    {
        public static void Create(PublicHolidayPay publicHolidayPay)
        {
            using (var context = new ERPContext())
            {
                context.Entry(publicHolidayPay).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static PublicHolidayPay[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.PublicHolidayPays.ToArray();
            }
        }

        public static PublicHolidayPay Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.PublicHolidayPays.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public static void Update(PublicHolidayPay publicHolidayPay)
        {
            using (var context = new ERPContext())
            {
                context.Entry(publicHolidayPay).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.PublicHolidayPays.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
