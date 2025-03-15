using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class CompanyInterface
    {
        public static void Create(Company company)
        {
            using (var context = new ERPContext())
            {
                context.Entry(company).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Company[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Companies.Where(t => t.Status == true).ToArray();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Companies.Count(t => t.Status == true);                
            }
        }

        public static Company Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Companies.Where(t => t.Id == id && t.Status == true).FirstOrDefault();
            }
        }
            
        public static void Update(Company company)
        {
            using (var context = new ERPContext())
            {
                context.Entry(company).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var companyRecord = context.Companies.Find(id);
                context.Entry(companyRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
