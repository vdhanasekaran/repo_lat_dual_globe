using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class OvertimeInterface
    {
        public static void Create(Overtime overtime)
        {
            using (var context = new ERPContext())
            {
                context.Entry(overtime).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Overtime[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Overtimes.ToArray();
            }
        }

        public static Overtime Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Overtimes.Where(i => i.Id == id).FirstOrDefault();
            }
        }


        public static void Update(Overtime overtime)
        {
            using (var context = new ERPContext())
            {
                context.Entry(overtime).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Overtimes.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
