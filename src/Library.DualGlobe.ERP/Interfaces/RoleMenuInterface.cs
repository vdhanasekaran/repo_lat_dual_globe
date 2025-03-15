using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class RoleMenuInterface
    {
        public static void Create(RoleMenu roleMenu)
        {
            using (var context = new ERPContext())
            {
                context.Entry(roleMenu).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static List<RoleMenu> Read()
        {
            using (var context = new ERPContext())
            {
                return context.RoleMenus.ToList();
            }
        }

        public static RoleMenu Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.RoleMenus.Where(t => t.Id == id).FirstOrDefault();

            }
        }

        public static RoleMenu ReadByRoleId(int roleID)
        {
            using (var context = new ERPContext())
            {
                return context.RoleMenus.Where(t => t.RoleId == roleID).FirstOrDefault();

            }
        }


        public static void Update(RoleMenu roleMenu)
        {
            using (var context = new ERPContext())
            {
                context.Entry(roleMenu).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.RoleMenus.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
