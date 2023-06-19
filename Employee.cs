using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace Company
{
    public class Employee
    {
        static int _idCounter = 0;
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string Department { get; }
        public static ArrayList DbEmployee = new ArrayList();
        public string[] DepartmentNames = { "IT", "HR", "Procurement", "Accounting", "Security" };

        public Employee(string fullname, string position, int salary, string department)
        {
            department.ToUpper();
            Fullname = fullname;
            Position = position.Length >= 2 ? position : throw new Exception("Position must contain minimum 2 alphabet");
            Salary = salary >= 250 ? salary : 250;
            foreach (string item in DepartmentNames)
            {
                if (department == item)
                {
                    Department = department;
                }
            }
            if (Department != department)
            {
                throw new Exception("Enter existing department name");
            }

            StringSegment departmentsFirstTwoLetter = new StringSegment(Department, 0, 2);
            No = $"{departmentsFirstTwoLetter.ToString().ToUpper()}{1000 + _idCounter}";
            _idCounter++;
            DbEmployee.Add(this);
        }
    }
}
/*
Employee class:
 
 - No - Iscinin Nomresini ifade edir, iscilerin nomreleri elave olunduqlari departamentin Ilk iki herfi 
        ve iscinin yaranma sirasindan ibaret olur ve iscilerin yaranma sirasi 1000-den baslanilir, 
        misalcun Maliyyet departamentiinde calisan ve sisteme 35-ci elave olunmus iscinin nomresi MA1035 olmalidir
 
 - Fullname - iscinin ad ve soyadi
 - Position - iscinin vezifesi (minimum 2 herfden ibaret olmalidir)
 - Salary - iscinin maasi 250-den asagi ola bilmez
 - DepartmentName - iscinin elave olundugu departmentin adi
*/