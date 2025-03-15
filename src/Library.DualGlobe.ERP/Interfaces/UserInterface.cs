using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class UserInterface
    {
        public static void Create(User user)
        {
            using (var context = new ERPContext())
            {
                context.Entry(user).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static User[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Users.Include(x => x.employee).ToArray();
            }
        }

        public static User Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Users.Where(t => t.Id == id)
                     .Include(x => x.employee).FirstOrDefault();
            }
        }

        public static User ReadByUsername(string username)
        {
            using (var context = new ERPContext())
            {
                return context.Users.Where(t => t.UserId == username)
                                    .Include(x => x.employee)
                                    .FirstOrDefault();
            }
        }

        public static void Update(User user)
        {
            using (var context = new ERPContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Users.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
