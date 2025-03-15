using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class CPFInterface
    {
        public static void Create(CPF cpf)
        {
            using (var context = new ERPContext())
            {
                context.Entry(cpf).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static CPF[] BulkInsert(List<CPF> cpf)
        {
            using (var context = new ERPContext())
            {
                context.CPFs.AddRange(cpf);
                context.SaveChanges();
                return cpf.ToArray();
            }
        }

        public static CPF[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.CPFs.ToArray();
            }
        }

        public static CPF Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.CPFs.Where(i => i.Id == id).FirstOrDefault();
            }
        }
        public static CPF ReadByEmployee(int id)
        {
            using (var context = new ERPContext())
            {
                return context.CPFs.Where(i => i.EmployeeId == id && i.Date.Month == DateTime.Today.Month && i.Date.Year == DateTime.Today.Year).FirstOrDefault();
            }
        }

        public static CPF ReadByEmployeeYearAndMonth(int empId, int year, int month)
        {
            using (var context = new ERPContext())
            {
                return context.CPFs.Where(i => i.EmployeeId == empId && i.Date.Month == month && i.Date.Year == year).FirstOrDefault();
            }
        }

        public static CPF[] ReadByYearAndMonth(int year, int month)
        {
            using (var context = new ERPContext())
            {
                return context.CPFs.Where(i => i.Date.Month == month && i.Date.Year == year).ToArray();
            }
        }

        public static void Update(CPF cpf)
        {
            using (var context = new ERPContext())
            {
                context.Entry(cpf).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.CPFs.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        //mks
        public static CPFLookup[] ReadLookupValbyAgeYear(int prYearCount, int age)
        {
            using (var context = new ERPContext())
            {
                return context.CPFLookups.Where(i => i.CPFLookUpYear == prYearCount && i.EffectiveDate <= DateTime.Today && i.AgeMaxVal > age && i.AgeMinVal < age).ToArray();
            }
        }
    }
}
