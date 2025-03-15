using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class UserRoleInterface
    {
        public static void Create(UserRole userRole)
        {
            using (var context = new ERPContext())
            {
                context.Entry(userRole).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static UserRole[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.UserRoles.ToArray();
            }
        }

        public static UserRole Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.UserRoles.Where(t => t.Id == id).FirstOrDefault();

            }
        }

        public static UserRole[] ReadByUserRolename(string userId)
        {
            using (var context = new ERPContext())
            {
                return context.UserRoles.Where(x => x.UserId == userId)
                    .Include(x => x.Role)
                    .ToArray();

            }
        }

        public static void Update(UserRole userRole)
        {
            using (var context = new ERPContext())
            {
                context.Entry(userRole).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.UserRoles.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
