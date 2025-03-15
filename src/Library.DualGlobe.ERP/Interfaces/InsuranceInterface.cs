using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class InsuranceInterface
    {
        public static void Create(Insurance insurance)
        {
            using (var context = new ERPContext())
            {
                context.Entry(insurance).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Insurance[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Insurances.ToArray();
            }
        }

        public static Insurance[] ReadExpiringInsurance()
        {
            List<Insurance> insuranceList = new List<Insurance>();
            using (var context = new ERPContext())
            {
                foreach (var data in context.Insurances.ToList())
                {
                    if ((data.EndDate.Value - DateTime.Today).Days < 30)
                        insuranceList.Add(data);
                }
            }
            return insuranceList.ToArray();
        }

        public static Insurance Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Insurances.Where(i => i.Id == id).FirstOrDefault();
            }
        }
        public static Insurance ReadByPolicyNumber(string policyNumber)
        {
            using (var context = new ERPContext())
            {
                return context.Insurances.Where(i => i.InsurancePolicyNumber == policyNumber).FirstOrDefault();
            }
        }

        public static Insurance[] ReadByType(string type)
        {
            using (var context = new ERPContext())
            {
                return context.Insurances.Where(i => i.InsuranceType == type).ToArray();
            }
        }
        


        public static void Update(Insurance insurance)
        {
            using (var context = new ERPContext())
            {
                context.Entry(insurance).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Insurances.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        
    }
}
