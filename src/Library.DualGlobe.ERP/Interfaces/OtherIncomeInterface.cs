using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class OtherIncomeInterface
    {
        public static void Create(OtherIncome otherIncome)
        {
            using (var context = new ERPContext())
            {
                context.Entry(otherIncome).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static OtherIncome[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.OtherIncomes.ToArray();
            }
        }

        public static OtherIncome[] ReadByMonthAndYear(int month, int year)
        {
            using (var context = new ERPContext())
            {
                return context.OtherIncomes.Where(i=>i.IncomeDate.Month == month && i.IncomeDate.Year == year).ToArray();
            }
        }

        public static OtherIncome[] ReadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                return context.OtherIncomes.Where(x => x.IncomeDate >= startDate && x.IncomeDate <= endDate)
                                     .ToArray();
            }
        }

        public static OtherIncome Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.OtherIncomes.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public static void Update(OtherIncome otherIncome)
        {
            using (var context = new ERPContext())
            {
                context.Entry(otherIncome).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var otherIncomeRecord = context.OtherIncomes.Find(id);
                context.Entry(otherIncomeRecord).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
