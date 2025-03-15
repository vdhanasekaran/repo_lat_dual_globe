using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class DonationInterface
    {
        public static void Create(Donation donation)
        {
            using (var context = new ERPContext())
            {
                context.Entry(donation).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public static Donation[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.Donations.ToArray();
            }
        }

        public static Donation Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.Donations.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        public static Donation[] ReadbyNationality(string nationality)
        {
            using (var context = new ERPContext())
            {
                return context.Donations.Where(t => t.Nationality == nationality).ToArray();
                                               
            }
        }

        public static Donation[] ReadbyReligion(string religion)
        {
            using (var context = new ERPContext())
            {
                return context.Donations.Where(t => t.Religion == religion).ToArray();

            }
        }

        public static Donation[] ReadbyDonationType(string donationType)
        {
            using (var context = new ERPContext())
            {
                return context.Donations.Where(t => t.DonationType == donationType).ToArray();

            }
        }

        public static void Update(Donation donation)
        {
            using (var context = new ERPContext())
            {
                context.Entry(donation).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Donations.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
