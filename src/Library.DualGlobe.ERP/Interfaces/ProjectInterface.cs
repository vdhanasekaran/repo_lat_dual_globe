using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class ProjectInterface
    {
        public static void Create(Project project)
        {
            using (var context = new ERPContext())
            {
                context.Entry(project).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Projects.Count();
            }
        }
        public static Project[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Projects.Include(c => c.client).ToArray();
            }
        }

        public static Project[] ReadByClientId(int clientId)
        {
            using (var context = new ERPContext())
            {
                return context.Projects.Where(t => t.ClientId == clientId).Include(c => c.client).OrderBy(p => p.Id).ToArray();
            }
        }

        public static Project Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Projects.Where(t => t.Id == id).Include(c => c.client).FirstOrDefault();
            }
        }

        public static void Update(Project project)
        {
            using (var context = new ERPContext())
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var projectRecord = context.Projects.Find(id);
                context.Entry(projectRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
