using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class RoleInterface
    {
        public static void Create(Role role)
        {
            using (var context = new ERPContext())
            {
                context.Entry(role).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Role[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Roles.ToArray();
            }
        }

        public static Role Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Roles.Where(t => t.Id == id).FirstOrDefault();

            }
        }

        
        public static void Update(Role role)
        {
            using (var context = new ERPContext())
            {
                context.Entry(role).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Roles.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
