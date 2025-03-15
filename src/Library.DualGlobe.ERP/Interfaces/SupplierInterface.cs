using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class SupplierInterface
    {
        public static void Create(Supplier supplier)
        {
            using (var context = new ERPContext())
            {
                context.Entry(supplier).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Supplier[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Suppliers.ToArray();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Suppliers.Count();                
            }
        }

        public static Supplier Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Suppliers.Where(t => t.Id == id).FirstOrDefault();
            }
        }
            
        public static void Update(Supplier supplier)
        {
            using (var context = new ERPContext())
            {
                context.Entry(supplier).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var supplierRecord = context.Suppliers.Find(id);
                context.Entry(supplierRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
