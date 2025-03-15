using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class RestDayPayInterface
    {
        public static void Create(RestDayPay restDayPay)
        {
            using (var context = new ERPContext())
            {
                context.Entry(restDayPay).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static RestDayPay[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.RestDayPays.ToArray();
            }
        }

        public static RestDayPay Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.RestDayPays.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public static RestDayPay ReadByGroupName(string groupName)
        {
            using (var context = new ERPContext())
            {
                return context.RestDayPays.Where(i => string.Compare(i.GroupName, groupName, StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();
            }
        }

        public static void Update(RestDayPay restDayPay)
        {
            using (var context = new ERPContext())
            {
                context.Entry(restDayPay).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.RestDayPays.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
