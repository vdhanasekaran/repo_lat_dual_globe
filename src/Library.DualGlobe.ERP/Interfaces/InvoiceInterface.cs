using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System.Linq;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class InvoiceInterface
    {
        public static void Create(Invoice invoice)
        {
            using (var context = new ERPContext())
            {
                context.Entry(invoice).State = EntityState.Added;
                context.SaveChanges();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.Invoices.Count(t => t.Status == "UnPaid");
            }
        }

        public static Invoice[] Read()
        {
            using (var context = new ERPContext())
            {
                //return context.Invoices
                //      .Include(t => t.InvoicePhases)
                //      .Include(t => t.Clients)
                //      .Include(t => t.Quotations)
                //      .ToArray();

                var InvoiceArray = (from i in context.Invoices
                                    join c in context.Clients
                                    on i.ClientId equals c.Id
                                    join q in context.Quotations
                                    on i.QuotationId equals q.Id
                                    select i
                                    )
                                     .ToArray();
                return InvoiceArray;

            }
        }

        public static Invoice[] ReadByQuotationId(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Invoices
                    .Where(i => i.QuotationId == id)
                    .Include(t => t.InvoicePhases)
                    .Include(t => t.Payments)
                    .ToArray();
            }
        }

        public static Invoice[] ReadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                return context.Invoices
                    .Where(i => i.InvoiceDate.Value >= startDate && i.InvoiceDate.Value <= endDate)
                    .Include(t => t.InvoicePhases)
                    .Include(t => t.Payments)
                    .ToArray();
            }
        }

        public static InvoicePhase[] ReadInvoicePhaseByInvoice(int id)
        {
            using (var context = new ERPContext())
            {
                return context.InvoicePhases
                    .Where(i => i.InvoiceId == id)
                    .ToArray();
            }
        }



        public static Invoice Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Invoices.Where(t => t.Id == id)
                                                .Include(t => t.InvoicePhases)
                                                .Include(t => t.Payments)
                                                .FirstOrDefault();
            }
        }


        public static void Update(Invoice Invoice)
        {
            using (var context = new ERPContext())
            {
                context.Entry(Invoice).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Invoices.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void UpdateInvoicePhase(InvoicePhase invoicePhase)
        {
            using (var context = new ERPContext())
            {
                context.Entry(invoicePhase).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void CreateInvoicePhase(InvoicePhase invoicePhase)
        {
            using (var context = new ERPContext())
            {
                context.Entry(invoicePhase).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void UpdateInvoicePhaseItem(InvoicePhase InvoicePhaseItem)
        {
            using (var context = new ERPContext())
            {
                context.Entry(InvoicePhaseItem).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void CreateInvoicePhaseItem(InvoicePhase InvoicePhaseItem)
        {
            using (var context = new ERPContext())
            {
                context.Entry(InvoicePhaseItem).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void DeleteInvoicePhase(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.InvoicePhases.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


    }
}
