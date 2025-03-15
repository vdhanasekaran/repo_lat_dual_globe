using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class LoanAndAdvanceInterface
    {
        public static void Create(LoanAndAdvance loanAndAdvance)
        {
            using (var context = new ERPContext())
            {
                context.Entry(loanAndAdvance).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static LoanAndAdvance[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.LoanAndAdvances
                    .Include(t => t.loanAndAdvanceDetails)
                    .Include(t => t.employee)
                    .ToArray();
            }
        }

        public static LoanAndAdvance[] ReadByMonth(DateTime loanDate)
        {
            using (var context = new ERPContext())
            {
                return context.LoanAndAdvances.Where(t => t.LoanDate.Month == loanDate.Month && t.LoanDate.Year == loanDate.Year)
                                                            .Include(t => t.loanAndAdvanceDetails)
                                                            .Include(t => t.employee)
                                                            .ToArray();
            }
        }

        public static LoanAndAdvance[] ReadByEmployeeMonthYear(int empId,int month, int year)
        {
            using (var context = new ERPContext())
            {
                return context.LoanAndAdvances.Where(t => t.LoanDate.Month == month && t.LoanDate.Year == year
                                                            && t.EmployeeId == empId)                                                            
                                                            .Include(t => t.loanAndAdvanceDetails)
                                                            .ToArray();
            }
        }

        public static LoanAndAdvance Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.LoanAndAdvances.Where(t => t.Id == id)
                                                .Include(t => t.loanAndAdvanceDetails)
                                                .FirstOrDefault();
            }
        }


        public static LoanAndAdvance[] ReadByEmployeeId(int id)
        {
            using (var context = new ERPContext())
            {
                return context.LoanAndAdvances.Where(t => t.EmployeeId == id)
                                        .Include(t => t.loanAndAdvanceDetails)
                                        .ToArray();
            }
        }   
        
        public static void Update(LoanAndAdvance loanAndAdvance)
        {
            using (var context = new ERPContext())
            {
                context.Entry(loanAndAdvance).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Update(LoanAndAdvanceDetails loanAndAdvanceDetails)
        {
            using (var context = new ERPContext())
            {
                context.Entry(loanAndAdvanceDetails).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void InsertLoanAndAdvanceDetail(LoanAndAdvanceDetails loanAndAdvanceDetails)
        {
            using (var context = new ERPContext())
            {
                context.Entry(loanAndAdvanceDetails).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var loanAdvance = context.LoanAndAdvances.Find(id);
                for (int i = 0; i < loanAdvance.loanAndAdvanceDetails.Count; i++)
                {
                    var type = loanAdvance.loanAndAdvanceDetails[i];
                    loanAdvance.loanAndAdvanceDetails.Remove(type);
                }
                context.Entry(loanAdvance).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
