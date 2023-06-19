using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace Company
{
    public class Department
    {
        int _workerLimit = 1;
        int _employeeCounter = 0;
        int _averageSalaryCounter = 0;
        StringSegment _initialOfDepartment;
        public string Name { get; set; }
        public int WorkerLimit { get { return _workerLimit; } set { _workerLimit = value >= 1 ? value : throw new Exception("Department must have minimum 1 employee"); } }
        public int SalaryLimit { get; set; }
        public static ArrayList Employees { get; set; } = Employee.DbEmployee;
        public static ArrayList DbDepartments = new ArrayList();
        public int CalcSalaryAverage()
        {

            foreach (Employee item in Employees)
            {
                StringSegment initialOfDepartmentChecker = new StringSegment(item.Department, 0, 2);
                if (initialOfDepartmentChecker == _initialOfDepartment)
                {
                    _averageSalaryCounter += item.Salary;
                    _employeeCounter++;
                }
            }
            return _averageSalaryCounter / _employeeCounter;
        }
        public Department(string name, int salaryLimit)
        {
            name.ToUpper();
            Name = name.Length >= 2 ? name : throw new Exception("Department name must contain minimum 2 alphabet");
            SalaryLimit = salaryLimit >= 250 ? salaryLimit : 250;
            _initialOfDepartment = new StringSegment(Name, 0, 2);
        }
    }
}

/*
 Department class:
 
 - Name - Departamentin adini ifade edir, departament adi minimum 2 herfden ibaret olmalidir
 - WorkerLimit - Departmanetde maximum var ola bilicek isci sayini ifade edir, minimum 1 ola biler
 - SalaryLimit - Departamentde butun isceleri ayliq cemi verilecek maximum meblegi ifade edir, minimum 250 ola biler
 - Employees - Departamentdeki iscileri ifade edir.Departamente elave olunmus iscilerin siyahisini iafe edir
 - CalcSalaryAverage() - departamentdeki iscilerin maas ortalamasini qaytaran method
 */