using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company
{
    public class HRManager
    {
        public static ArrayList Departments = Department.DbDepartments;
        public static ArrayList Employees = Employee.DbEmployee;
        public static void AddDepartment(string name, int salaryLimit)
        {
            Department newDepartment = new Department(name, salaryLimit);
            foreach (Department item in Departments)
            {
                if (item.Name == newDepartment.Name)
                {
                    throw new Exception("Duplicate department name...");
                }
            }
            Departments.Add(newDepartment);
        }
        public static void GetDepartments()
        {
            foreach (Department item in Departments)
            {
                Console.WriteLine(item.Name);
            }
        }
        public static void AddEmployee(string fullname, string position, int salary, string department)
        {
            Employee newEmployee = new Employee(fullname, position, salary, department);
            Employees.Add(newEmployee);
        }
        public static void EditDepartaments(string departmentName, string newDepartmentName)
        {
            foreach (Department item in Departments)
            {
                if (item.Name == departmentName)
                {
                    item.Name = newDepartmentName;
                }
            }
        }
        public static void RemoveEmployee(string employeeNo, string fullname)
        {
            bool _employeeNotFound = true;
            foreach (Employee item in Employees)
            {
                if (item.No == employeeNo && item.Fullname == fullname)
                {
                    Employees.Remove(item);
                    _employeeNotFound = false;
                }
            }
            if (_employeeNotFound)
            {
                throw new Exception($"There is no existing employee with No:{employeeNo} & Fullname:{fullname}");
            }
        }
        public static void EditEmployee(string employeeNo, string newEmployeeNo, string newFullname, int newSalary, string newPosition)
        {
            bool _employeeNotFound = true;

            foreach (Employee item in Employees)
            {
                if (item.No == employeeNo)
                {
                    item.No = newEmployeeNo;
                    item.Fullname = newFullname;
                    item.Salary = newSalary;
                    _employeeNotFound = false;
                }
            }
            if (_employeeNotFound)
            {
                throw new Exception($"There is no existing employee with No:{employeeNo}");
            }
        }
    }
}
/*
IHumanResourceManager

 - Departments - sistemdeki departamentler siyahisini ifade edir
 - AddDepartment() -departament yaratmaq ucun lazimli melumatlari parameter olaraq qebul edib, yaradib,
                     departamenets arrayina elave eden metod
 - GetDepartments() -sistemdeki butun departamentleri geriye qaytaran 
 - EditDepartaments() -departamentin uzerinde deyisiklik - departamentin adi deyisdirile biler ve parameter oaraq deyisdirmek istediyi
                        departamentin adini ve yeni adini gonderir

 - AddEmployee() -parametr olaraq employee yaranmasi ucun lazi olan melimatlar ve departament name gonderilir.Method icinde employe yaradilir
                   ve gonderilmis nomresli departamentin employees arrayine elave edilir

-  RemoveEmployee() -parametr olaraq employee nomresi ve department adi gondeirlir ve gonderilmis nomreli employee-ni 
- EditEmploye() -paramters: nomersi, fullname, salary ve position
*/