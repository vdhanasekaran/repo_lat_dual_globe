using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class WorkPermitAddressInterface
    {
        public static void Create(WorkPermitAddress workPermitAddress)
        {
            using (var context = new ERPContext())
            {
                context.Entry(workPermitAddress).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static WorkPermitAddress[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.WorkPermitAddresses.ToArray();
            }
        }

        public static WorkPermitAddress Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.WorkPermitAddresses.Where(i => i.Id == id).FirstOrDefault();
            }
        }

        public static void Update(WorkPermitAddress workPermitAddress)
        {
            using (var context = new ERPContext())
            {
                context.Entry(workPermitAddress).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.WorkPermitAddresses.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
