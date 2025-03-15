using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class ExpenseCategoryInterface
    {
        public static void Create(ExpenseCategory expenseCategory)
        {
            using (var context = new ERPContext())
            {
                context.Entry(expenseCategory).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static ExpenseCategory[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.ExpenseCategorys.ToArray();
            }
        }
        public static int GetCount()
        {
            using (var context = new ERPContext())
            {
                return context.ExpenseCategorys.Count();                
            }
        }

        public static ExpenseCategory Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.ExpenseCategorys.Where(t => t.Id == id).FirstOrDefault();
            }
        }
            
        public static void Update(ExpenseCategory expenseCategory)
        {
            using (var context = new ERPContext())
            {
                context.Entry(expenseCategory).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var ExpenseCategoryRecord = context.ExpenseCategorys.Find(id);
                context.Entry(ExpenseCategoryRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
