using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class QuotationInterface
    {
        public static void Create(Quotation quotation)
        {
            using (var context = new ERPContext())
            {
                context.Entry(quotation).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Quotations.Count();
            }
        }
        public static Quotation[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Quotations
                    //.Include(t => t.quotationItems)
                    .ToArray();
            }
        }

        public static Quotation Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Quotations.Where(t => t.Id == id)
                                                .Include(t => t.quotationItems)
                                                .FirstOrDefault();
            }
        }
        public static Quotation[] ReadByClientId(int clientId)
        {
            using (var context = new ERPContext())
            {
                return context.Quotations.Where(t => t.ClientId == clientId).OrderBy(p => p.Id).ToArray();
            }
        }

        public static Quotation[] ReadByProjectId(int projectId)
        {
            using (var context = new ERPContext())
            {
                return context.Quotations.Where(t => t.ProjectId == projectId).OrderBy(p => p.Id).ToArray();
            }
        }

        public static void Update(Quotation quotation)
        {
            using (var context = new ERPContext())
            {
                context.Entry(quotation).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void UpdatequotationDetail(QuotationItems quotationItems)
        {
            using (var context = new ERPContext())
            {
                context.Entry(quotationItems).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void InsertquotationDetail(QuotationItems quotationItems)
        {
            using (var context = new ERPContext())
            {
                context.Entry(quotationItems).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Quotations.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void DeleteQuotationDetail(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.QuotationItems.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
