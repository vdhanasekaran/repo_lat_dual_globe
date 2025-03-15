using System;
using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class SalaryDetailInterface
    {
        public static void Create(SalaryDetail SalaryDetail)
        {
            using (var context = new ERPContext())
            {
                context.Entry(SalaryDetail).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static void BulkInsert(List<SalaryDetail> salaryList)
        {
            using (var context = new ERPContext())
            {
                context.SalaryDetails.AddRange(salaryList);
                context.SaveChanges();                
            }
        }

        public static SalaryDetail[] Read()
        {
            using (var context = new ERPContext())
            {
                 return context.SalaryDetails                             
                              .ToArray();
            }
        }

        public static SalaryDetail[] ReadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                return context.SalaryDetails.Where(x => x.DateCreated >= startDate && x.DateCreated <= endDate)
                                     .ToArray();
            }
        }

        public static SalaryDetail[] ReadByMonthYear(string month, string year)
        {
            using (var context = new ERPContext())
            {
                return context.SalaryDetails
                               .Where(x => x.SalaryMonth == month && x.SalaryYear == year).ToArray();
            }
        }

        public static SalaryDetail[] ReadByStatusMonthYear(string month, string year, string workStatus)
        {
            using (var context = new ERPContext())
            {
                return context.SalaryDetails
                               .Where(x => x.SalaryMonth == month && x.SalaryYear == year && x.WorkStatus == workStatus).ToArray();
            }
        }

        public static SalaryDetail[] ReadByWorkStatus(DateTime startDate, DateTime endDate, string workStatus)
        {
            using (var context = new ERPContext())
            {
                return context.SalaryDetails.Where(x => x.DateCreated >= startDate && x.DateCreated <= endDate
                                                    && x.WorkStatus == workStatus).ToArray();
            }
        }

        public static SalaryDetail ReadById(int id)
         {
            using (var context = new ERPContext())
            {
                return context.SalaryDetails.Where(t=> t.Id== id).FirstOrDefault();
            }
         }
        
         public static SalaryDetail ReadByEmployeeId(int id)
         {
            using (var context = new ERPContext())
            {
               return context.SalaryDetails                                                   
                              .Where(x => x.EmployeeId == id).FirstOrDefault();
            }
         }

        public static SalaryDetail ReadByEmployeeIdAndDate(int id, string month, string year)
        {
            using (var context = new ERPContext())
            {
                return context.SalaryDetails
                               .Where(x => x.EmployeeId == id && x.SalaryMonth == month && x.SalaryYear == year).FirstOrDefault();
            }
        }


        public static void Update(SalaryDetail SalaryDetail)
        {
            using (var context = new ERPContext())
            {
                context.Entry(SalaryDetail).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.SalaryDetails.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
