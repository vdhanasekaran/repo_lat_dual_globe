using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class ExpenseInterface
    {
        public static void Create(Expense materialPurchase)
        {
            using (var context = new ERPContext())
            {
                context.Entry(materialPurchase).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Expense[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Expenses.Include(i=> i.Documents)
                    .ToArray();
            }
        }

        public static Expense Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Expenses.Where(t => t.Id == id)
                .Include(i => i.Documents)
                                                .FirstOrDefault();
            }
        }

        public static Expense[] ReadByMonthAndYear(int month, int year)
        {
            using (var context = new ERPContext())
            {
                return context.Expenses.Where(i => i.Date.Month == month && i.Date.Year == year).Include(i => i.Documents).ToArray();
            }
        }

        public static Expense[] ReadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                return context.Expenses.Where(x => x.Date >= startDate && x.Date <= endDate).Include(i => i.Documents)
                                     .ToArray();
            }
        }

        public static Expense[] ReadByProjectId(int projectId)
        {
            using (var context = new ERPContext())
            {
                return context.Expenses.Where(t => t.ProjectId == projectId).OrderBy(p => p.Id).ToArray();
            }
        }

        public static Expense[] ReadByClientId(int clientId)
        {
            using (var context = new ERPContext())
            {
                return context.Expenses.Where(t => t.ClientId == clientId).OrderBy(p => p.Id).ToArray();
            }
        }

        public static void Update(Expense materialPurchase)
        {
            using (var context = new ERPContext())
            {
                context.Entry(materialPurchase).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Expenses.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void DeleteDocument(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Expenses.SelectMany(t => t.Documents);
                var document = data.Where(j => j.Id == id).FirstOrDefault();
                context.Entry(document).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void InsertDocument(Document record, Expense parent)
        {
            using (var context = new ERPContext())
            {
                record.Expense = parent;
                context.Entry(parent).State = EntityState.Unchanged;
                context.Entry(record).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
