using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class LevyLookupInterface
    {
        public static decimal GetLevy(Employee emp, DateTime date)
        {


            using (var context = new ERPContext())
            {
                decimal returnVal = 0;

                try
                {
                    var levy = context.LevyLookups.Where(t => t.ToDate >= date && t.FromDate <= date);
                    if (emp.WorkStatus == "WorkPermit")
                    {
                        if (emp.MYE.GetValueOrDefault())
                        {
                            if (string.Compare(emp.Skill, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                if (levy != null)
                                    returnVal = levy.Where(l => l.PassType == emp.WorkStatus).FirstOrDefault().MYNBasicSkilled.GetValueOrDefault(0);
                            }
                            else
                            {
                                if (levy != null)
                                    returnVal = levy.Where(l => l.PassType == emp.WorkStatus).FirstOrDefault().MYNHighSkilled.GetValueOrDefault(0);
                            }
                        }
                        else
                        {
                            if (string.Compare(emp.Skill, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                if (levy != null)
                                    returnVal = levy.Where(l => l.PassType == emp.WorkStatus).FirstOrDefault().MYNWaiverBasicSkilled.GetValueOrDefault(0);
                            }
                            else
                            {
                                if (levy != null)
                                    returnVal = levy.Where(l => l.PassType == emp.WorkStatus).FirstOrDefault().MYNWaiverHighSkilled.GetValueOrDefault(0);
                            }
                        }
                    }
                    else if (emp.WorkStatus == "SPass")
                    {
                        if (string.Compare(emp.TierType, "Basic", StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (levy != null)
                                returnVal = levy.Where(l => l.PassType == emp.WorkStatus).FirstOrDefault().BasicTier.GetValueOrDefault(0);
                        }
                        else
                        {
                            if (levy != null)
                                returnVal = levy.Where(l => l.PassType == emp.WorkStatus).FirstOrDefault().Tier2.GetValueOrDefault(0);
                        }
                    }
                }
                catch (Exception)
                {
                    returnVal = 0;
                }
                return returnVal;
            }
        }
    }
}
