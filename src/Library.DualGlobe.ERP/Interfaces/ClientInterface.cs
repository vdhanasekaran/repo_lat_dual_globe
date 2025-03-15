using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class ClientInterface
    {
        public static void Create(Client client)
        {
            using (var context = new ERPContext())
            {
                context.Entry(client).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Client[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Clients.Where(t=> t.Status == true)
                .Include(p=> p.projects)
                .ToArray();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Clients.Count(t => t.Status == true);                
            }
        }

        public static Client Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Clients.Where(t => t.Id == id && t.Status == true).Include(p => p.projects).FirstOrDefault();
            }
        }
            
        public static void Update(Client client)
        {
            using (var context = new ERPContext())
            {
                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var clientRecord = context.Clients.Find(id);
                context.Entry(clientRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
