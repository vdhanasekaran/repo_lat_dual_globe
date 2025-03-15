using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class WorkingHourInterface
    {
        public static void Create(WorkingHour workingHour)
        {
            using (var context = new ERPContext())
            {
                context.Entry(workingHour).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static WorkingHour[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.WorkingHours.ToArray();
            }
        }

        public static WorkingHour Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.WorkingHours.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        
        public static void Update(WorkingHour workingHour)
        {
            using (var context = new ERPContext())
            {
                context.Entry(workingHour).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.WorkingHours.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
