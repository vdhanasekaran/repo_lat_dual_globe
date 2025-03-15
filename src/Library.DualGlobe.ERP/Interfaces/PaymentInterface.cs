using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System.Linq;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class PaymentInterface
    {
        public static void Create(Payment payment)
        {
            using (var context = new ERPContext())
            {
                context.Entry(payment).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Payment[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Payments.ToArray();
            }
        }

        public static Payment Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Payments.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public static Payment[] ReadByInvoice(int invoiceId)
        {
            using (var context = new ERPContext())
            {
                return context.Payments.Where(t => t.InvoiceId == invoiceId).ToArray();
            }
        }

        public static void Update(Payment payment)
        {
            using (var context = new ERPContext())
            {
                context.Entry(payment).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Payments.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
