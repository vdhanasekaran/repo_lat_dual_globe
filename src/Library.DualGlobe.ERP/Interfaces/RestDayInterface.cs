using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class RestDayInterface
    {
        public static void Create(RestDay restDay)
        {
            using (var context = new ERPContext())
            {
                context.Entry(restDay).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static RestDay[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.RestDays.Include(i => i.RestDates).ToArray();
            }
        }

        public static RestDay Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.RestDays.Where(i=>i.Id == id).Include(i => i.RestDates).FirstOrDefault();
            }
        }

        public static void Update(RestDay restDay)
        {
            using (var context = new ERPContext())
            {
                context.Entry(restDay).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.RestDays.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void UpdateRestDateDetail(RestDate restDates)
        {
            using (var context = new ERPContext())
            {
                context.Entry(restDates).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void InsertRestDateDetail(RestDate restDates)
        {
            using (var context = new ERPContext())
            {
                context.Entry(restDates).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void DeleteRestDateDetail(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.RestDates.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
