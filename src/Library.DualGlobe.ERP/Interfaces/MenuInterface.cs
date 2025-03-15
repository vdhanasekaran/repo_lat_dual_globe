using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class MenuInterface
    {
        public static void Create(Menu menu)
        {
            using (var context = new ERPContext())
            {
                context.Entry(menu).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Menu[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Menus.ToArray();
            }
        }

        public static Menu Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Menus.Where(t => t.Id == id).FirstOrDefault();

            }
        }

        
        public static void Update(Menu menu)
        {
            using (var context = new ERPContext())
            {
                context.Entry(menu).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Menus.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
