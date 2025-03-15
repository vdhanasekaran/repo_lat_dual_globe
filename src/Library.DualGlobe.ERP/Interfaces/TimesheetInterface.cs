using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class TimesheetInterface
    {
        public static void Create(Timesheet Timesheet)
        {
            using (var context = new ERPContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Entry(Timesheet).State = EntityState.Added;
                context.Entry(Timesheet.employee).State = EntityState.Unchanged;
                context.SaveChanges();
            }
        }

        public static Timesheet[] BulkInsert(List<Timesheet> timesheet)
        {
            using (var context = new ERPContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Timesheets.AddRange(timesheet);
                context.SaveChanges();
                return timesheet.ToArray();
            }
        }

        public static Timesheet[] ReadByEmployeeYear(int empId, int year)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t => t.TimesheetDate.Year == year && t.EmployeeId == empId)
                                           .ToArray();
            }
        }

        public static Timesheet[] ReadByEmployeMonthYear(int empId, int month, int year)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t => t.TimesheetDate.Month == month
                                                && t.TimesheetDate.Year == year
                                                && t.EmployeeId == empId)
                                                .ToArray();
            }
        }

        public static Timesheet[] ReadByEmployeestatusProjectAndDate(string clientId, string projectId, DateTime timesheetDate, string status)
        {
            using (var context = new ERPContext())
            {
                if ((!string.IsNullOrEmpty(status)) && (!string.IsNullOrEmpty(projectId)))
                {
                    int projectIdValue = Convert.ToInt32(projectId);
                    return context.Timesheets.Include(t => t.employee)
                                             .Where(t => t.TimesheetDate == timesheetDate && t.ProjectId == projectIdValue && t.employee.WorkStatus == status).ToArray();
                }

                else if ((!string.IsNullOrEmpty(status)) && (!string.IsNullOrEmpty(clientId)))
                {
                    int clientIdValue = Convert.ToInt32(clientId);
                    return context.Timesheets.Include(t => t.employee)
                                             .Where(t => t.TimesheetDate == timesheetDate && t.ClientId == clientIdValue && t.employee.WorkStatus == status).ToArray();
                }

                else if (!string.IsNullOrEmpty(projectId))
                {
                    int projectIdValue = Convert.ToInt32(projectId);
                    return context.Timesheets.Include(t => t.employee)
                                             .Where(t => t.TimesheetDate == timesheetDate && t.ProjectId == projectIdValue).ToArray();
                }

                else if (!string.IsNullOrEmpty(clientId))
                {
                    int clientIdValue = Convert.ToInt32(clientId);
                    return context.Timesheets.Include(t => t.employee)
                                             .Where(t => t.TimesheetDate == timesheetDate && t.ClientId == clientIdValue).ToArray();
                }

                else if (!string.IsNullOrEmpty(status))
                {
                    return context.Timesheets.Include(t => t.employee)
                                             .Where(t => t.TimesheetDate == timesheetDate && t.employee.WorkStatus == status).ToArray();
                }

                else {
                    //Default
                    return context.Timesheets.Where(t => t.TimesheetDate == timesheetDate).ToArray();

                }

            }
        }

        public static Timesheet[] ReadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t => t.TimesheetDate >= startDate && t.TimesheetDate <= endDate)
                                             .ToArray();
            }
        }

        public static Timesheet[] ReayByEmployeeDate(int empId, DateTime startDate)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t =>t.EmployeeId == empId && t.TimesheetDate == startDate).ToArray();
            }
        }

        public static Timesheet[] ReadByDate(DateTime startDate)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t => t.TimesheetDate == startDate).ToArray();
            }
        }

        public static Timesheet[] ReadByProjectStartDateEndDate(DateTime startDate, DateTime endDate, int projectId)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t => t.TimesheetDate >= startDate && t.TimesheetDate <= endDate
                                               && t.ProjectId == projectId)
                                              .ToArray();
            }
        }

        public static Timesheet[] ReadByClientStartDateEndDate(DateTime startDate, DateTime endDate, int clientId)
        {
            using (var context = new ERPContext())
            {
                return context.Timesheets.Where(t => t.TimesheetDate >= startDate && t.TimesheetDate <= endDate
                                               && t.ClientId == clientId)
                                              .ToArray();
            }
        }

        public static void Update(Timesheet Timesheet)
        {
            using (var context = new ERPContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Entry(Timesheet).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.Timesheets.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void Delete(int id, DateTime timesheetDate)
        {
            using (var context = new ERPContext())
            {
                var data = context.Timesheets.Where(t => t.EmployeeId == id && t.TimesheetDate == timesheetDate);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public static void UpdateLeave(int empId, DateTime startdate, DateTime endDate)
        {
            using (var context = new ERPContext())
            {
                var timesheetArray = context.Timesheets.Where(t => t.EmployeeId == empId && t.TimesheetDate >= startdate && t.TimesheetDate <= endDate).ToList();

                if (timesheetArray != null & timesheetArray.Any())
                {
                    foreach (var timesheet in timesheetArray)
                    {
                        context.Configuration.AutoDetectChangesEnabled = false;
                        context.Entry(timesheet).State = EntityState.Deleted;
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
