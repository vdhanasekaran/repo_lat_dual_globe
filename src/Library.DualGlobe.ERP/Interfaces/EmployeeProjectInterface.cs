using System.Linq;
using Library.DualGlobe.ERP.Models;
using System.Data.Entity;
using System;

namespace Library.DualGlobe.ERP.Interfaces
{
    public class EmployeeProjectInterface
    {
        public static bool Create(EmployeeProject employeeProject)
        {
            using (var context = new ERPContext())
            {
                var employeeProjects = context.EmployeeProjects
                                  .Include(x => x.employee)
                                  .Include(x => x.project).ToArray();
                if (employeeProjects.FirstOrDefault(x => x.EmployeeId == employeeProject.EmployeeId && x.projectId == employeeProject.projectId) == null)
                {
                    context.Entry(employeeProject).State = EntityState.Added;
                    context.SaveChanges();
                    return true;
                }
                else {
                    return false;
                }
            }
        }

        public static EmployeeProject[] Read()
        {
            using (var context = new ERPContext())
            {
                return context.EmployeeProjects
                              .Include(x => x.employee)
                              .Include(x => x.project).ToArray();
            }
        }

        public static EmployeeProject Read(int id)
        {
            using (var context = new ERPContext())
            {
                return context.EmployeeProjects.Where(t=> t.Id== id).FirstOrDefault();
            }
        }

        public static int ReadByEmployeeId(int empId)
        {
            using (var context = new ERPContext())
            {
                return context.EmployeeProjects.Where(t => t.EmployeeId == empId).FirstOrDefault().projectId;
            }
        }

        public static EmployeeProject[] ReadByEmployee(int id)
        {
            using (var context = new ERPContext())
            {
                return context.EmployeeProjects.Where(t => t.EmployeeId == id).ToArray();
            }
        }

        public static EmployeeProject[] ReadByProject(int id)
        {
            using (var context = new ERPContext())
            {
                return context.EmployeeProjects
                              .Include(x => x.employee)              
                              .Where(t => t.projectId == id).ToArray();
            }
        }

        public static EmployeeProject[] ReadByProjectAndEmployeeStatus(int id, string employeeStatus)
        {
            using (var context = new ERPContext())
            {
                return context.EmployeeProjects
                              .Include(x => x.employee)
                              .Where(t => t.projectId == id && t.employee.WorkStatus == employeeStatus).ToArray();
            }
        }

        public static void Update(EmployeeProject employeeProject)
        {
            using (var context = new ERPContext())
            {
                context.Entry(employeeProject).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (var context = new ERPContext())
            {
                var data = context.EmployeeProjects.Find(id);
                context.Entry(data).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
