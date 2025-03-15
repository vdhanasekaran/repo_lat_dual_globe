using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class OperationExpenseInterface
    {
        public static void Create(OperationExpense operationExpense)
        {
            using (var context = new ERPContext())
            {
                context.Entry(operationExpense).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static OperationExpense[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.OperationExpenses.ToArray();
            }
        }

        public static OperationExpense[] ReadByMonthAndYear(int month, int year)
        {
            using (var context = new ERPContext())
            {
                return context.OperationExpenses.Where(i => i.Date.Month == month && i.Date.Year == year).ToArray();
            }
        }

        public static OperationExpense[] ReadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                return context.OperationExpenses.Where(x => x.Date >= startDate && x.Date <= endDate)
                                     .ToArray();
            }
        }

        public static OperationExpense Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.OperationExpenses.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public static void Update(OperationExpense operationExpense)
        {
            using (var context = new ERPContext())
            {
                context.Entry(operationExpense).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var operationExpenseRecord = context.OperationExpenses.Find(id);
                context.Entry(operationExpenseRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
