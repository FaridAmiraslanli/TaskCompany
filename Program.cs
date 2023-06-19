using System;
using System.Collections;


namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            HRManager.AddDepartment("Security", 10000);
            HRManager.AddDepartment("HR", 10000);
            HRManager.AddDepartment("IT", 10000);
            HRManager.AddEmployee("Shahin Valiyev", "Senior Developer", 10000, "IT");
            HRManager.AddEmployee("Shahin Valiyev", "Senior Developer", 10000, "IT");
            HRManager.AddEmployee("Shahin Valiyev", "Senior Developer", 10000, "IT");
            HRManager.AddEmployee("Shahin Valiyev", "Senior Developer", 10000, "HR");
            HRManager.AddEmployee("Shahin Valiyev", "Senior Developer", 10000, "Security");


            //depatments list
            ShowDepartmentsList();
            CreateDepartment();
            ModifyDepartment();
            ListOfEmployees();
            AddEmployee();
            RemoveEmployee();
            EditEmployee();
            
        }

        public static void ShowDepartmentsList()
        {
            //depatments list

            Console.WriteLine("| Department | No.Employee | Avrg Salary |");
            foreach (Department department in HRManager.Departments)
            {
                int _empCounter = 0;
                int _salaryCounter = 0;
                Console.Write($"{department.Name} | ");
                foreach (Employee emp in HRManager.Employees)
                {
                    if (emp.Department == department.Name)
                    {
                        _salaryCounter += emp.Salary;
                        _empCounter++;
                    }
                }
                _salaryCounter = _empCounter > 0 ? _salaryCounter / _empCounter : _salaryCounter;
                Console.WriteLine($"{_empCounter} | {_salaryCounter}");
            }
        }
        public static void CreateDepartment()
        {
            //create department

            Console.WriteLine("Enter parameters for creating department:");
            Console.Write("Name: ");
            string nameOfDepartmentCreate = (Console.ReadLine() ?? "").ToUpper();
            Console.Write("Salary limit: ");
            int salaryLimit = int.Parse(Console.ReadLine() ?? "");
            nameOfDepartmentCreate.ToUpper();
            HRManager.AddDepartment(nameOfDepartmentCreate, salaryLimit);
        }

        public static void ModifyDepartment()
        {
            //modify department
            string nameOfDepartmentModify = "";
            bool modificationMatch = true;
            while (modificationMatch)
            {
                Console.Write("Enter department name for modification: ");
                nameOfDepartmentModify = (Console.ReadLine() ?? "").ToUpper();
                nameOfDepartmentModify.ToUpper();
                foreach (Department department in HRManager.Departments)
                {
                    if (department.Name == nameOfDepartmentModify)
                    {
                        Console.WriteLine("| Name | Salary Limit |");
                        Console.WriteLine($"| {department.Name} | {department.SalaryLimit}");
                        modificationMatch = false;
                    }
                }
                if (modificationMatch)
                {
                    Console.WriteLine($"{nameOfDepartmentModify} does not exist.");
                }
            }
            if (!modificationMatch)
            {
                Console.Write($"Enter new name to modify {nameOfDepartmentModify}: ");
                string newDepartmentName = (Console.ReadLine() ?? "").ToUpper();
                HRManager.EditDepartaments(nameOfDepartmentModify, newDepartmentName);
            } 
        }
        public static void ListOfEmployees()
        {
            //employees list
            Console.WriteLine("| No | Fullname | Department | Salary |");
            foreach (Employee employee in HRManager.Employees)
            {
                Console.WriteLine($"| {employee.No} | {employee.Fullname} | {employee.Department} | {employee.Salary} |");
            }

            bool departmentMatch = true;
            while (departmentMatch)
            {
                Console.Write($"Enter department name: ");
                string departmentName = (Console.ReadLine() ?? "").ToUpper();
                foreach (Employee employee in HRManager.Employees)
                {
                    if (employee.Department == departmentName)
                    {
                        Console.WriteLine($"| {employee.No} | {employee.Fullname} | {employee.Position} | {employee.Salary} |");
                        departmentMatch = false;
                    }
                }
                if (departmentMatch)
                {
                    Console.WriteLine($"{departmentName} does not exist");
                }
            }
        }
        public static void AddEmployee()
        {
        //adding employee
        head:
            try
            {
                Console.WriteLine("Add new employee:");
                Console.Write("Fullname: ");
                string empFullname = Console.ReadLine() ?? "";
                Console.Write("Position: ");
                string empPosition = Console.ReadLine() ?? "";
                Console.Write("Salary: ");
                int empSalary = int.Parse(Console.ReadLine() ?? "");
                Console.Write("Department: ");
                string empDepartment = (Console.ReadLine() ?? "").ToUpper();
                HRManager.AddEmployee(empFullname, empPosition, empSalary, empDepartment);
                Console.WriteLine("Employee successfully added.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error... Enter salary as an integer number:");
                goto head;
            }
            catch (Exception)
            {
                Console.WriteLine("Error... Enter existing department name:");
                goto head;
            }
        }
        public static void EditEmployee()
        {
            //editing employees

            bool empNoMatch = true;

            while (empNoMatch)
            {
                Console.Write("Enter employee No to modify: ");
                string editEmployeeNo = (Console.ReadLine() ?? "").ToUpper();
                foreach (Employee employee in HRManager.Employees)
                {
                    if (editEmployeeNo == employee.No)
                    {
                        Console.WriteLine("| No | Fullname | Position | Salary |");
                        Console.WriteLine($"| {employee.No} | {employee.Fullname} | {employee.Position} | {employee.Salary} |");
                    start:
                        try
                        {
                            Console.Write("Enter new position: ");
                            string newEmpPosition = Console.ReadLine() ?? "";
                            Console.Write("Enter new salary: ");
                            int newEmpSalary = int.Parse(Console.ReadLine() ?? "");
                            HRManager.EditEmployee(employee.No, employee.No, employee.Fullname, newEmpSalary, newEmpPosition);
                            empNoMatch = false;
                            Console.WriteLine("Employee successfully modified.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error... Enter salary as an integer number:");
                            goto start;
                        }
                    }
                }
            }
        }
        public static void RemoveEmployee()
        {
        //remove employee
        retry:
            try
            {
                Console.WriteLine("Enter employee details for deletion.");
                Console.Write("Fullname: ");
                string empFullnameDeletion = (Console.ReadLine() ?? "");
                Console.Write("Number: ");
                string empNoDeletion = (Console.ReadLine() ?? "").ToUpper();

                HRManager.RemoveEmployee(empNoDeletion, empFullnameDeletion);

                Console.WriteLine("| No | Fullname | Department | Salary |");
                foreach (Employee employee in HRManager.Employees)
                {
                    Console.WriteLine($"| {employee.No} | {employee.Fullname} | {employee.Department} | {employee.Salary} |");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("There is no existing employee... Try again.");
                goto retry;
            }
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

 Department class:
 
 - Name - Departamentin adini ifade edir, departament adi minimum 2 herfden ibaret olmalidir
 - WorkerLimit - Departmanetde maximum var ola bilicek isci sayini ifade edir, minimum 1 ola biler
 - SalaryLimit - Departamentde butun isceleri ayliq cemi verilecek maximum meblegi ifade edir,minimum 250 ola biler
 - Employees - Departamentdeki iscileri ifade edir.Departamente elave olunmus iscilerin siyahisini iafe edir
 - CalcSalaryAverage() - departamentdeki iscilerin maas ortalamasini qaytaran method


 IHumanResourceManager 

 - Departments  - sistemdeki departamentler siyahisini ifade edir
 - AddDepartment() - departament yaratmaq ucun lazimli melumatlari parameter olaraq qebul edib,yaradib,
                     departamenets arrayina elave eden metod
 - GetDepartments() - sistemdeki butun departamentleri geriye qaytaran 
 - EditDepartaments() - departamentin uzerinde deyisiklik - departamentin adi deyisdirile biler ve parameter oaraq deyisdirmek istediyi
                        departamentin adini ve yeni adini gonderir

 - AddEmployee() - parametr olaraq employee yaranmasi ucun lazi olan melimatlar ve departament name gonderilir.Method icinde employe yaradilir
                   ve gonderilmis nomresli departamentin employees arrayine elave edilir

-  RemoveEmployee() - parametr olaraq employee nomresi ve department adi gondeirlir ve gonderilmis nomreli employee-ni 
- EditEmploye() -  paramters: nomersi, fullname,salary ve position


 Proses:
 ShowDepartmentsList();
            CreateDepartment();
            ModifyDepartment();
            ListOfEmployees();
            AddEmployee();
            RemoveEmployee();
            EditEmployee();
 
 Layihe run olduqda console penceresinde edile bilinecek emeliyyatlarin adlari gosterilmelidir:

 1.1 - Departameantlerin siyahisini gostermek - console penceresine sistemedki departamentlerin adlari,
                                                isci sayi ve iscilerinin  maas ortalamalari gosterilmelidir

 1.2 - Departamenet yaratmaq   - yeni departamenet yaratmaq ucun lazim olan deyreler console-dan daxil edilmelidir,
                                 yanlis olduqda tekrar istenmelidir

 1.3 - Departmanetde deyisiklik etmek - consoledan deyisiklik edilecek departamaentin adi daxil edilir,
                                        eger o adda departament yoxdursa xeta mesaji verir ve proses menusuna qayidir, 
                                        yox eger varsa departamentin haziki deyerlerini gosterir ve yeni deyerleri daxil
                                         etmesini isteyir

 2.1 - Iscilerin siyahisini gostermek - sistemdeki butun iscilerin nomre, ad soyad, departament adi ve maasi gosterilir
 
 2.2 - Departamentdeki iscilerin siyahisini gostermrek  - consoledan departament adi daxil edilir ve hemin 
                                                          departamentdeki iscilerin nomre,ad soyad, vezife 
                                                          ve maas deyerleri gosterilir

 2.3 - Isci elave etmek - Yeni isci elave edilmesi ucun lazim olan melumatlarin console-dan daxil edilmesi istenilir, 
                          deyerler yanlis olduqda tekrar daxil edilmesi istenilir

 2.4 - Isci uzerinde deyisiklik etmek  - console-dan deyisikkik edilecek iscinin nomresi daxil edilir,
                                         o nomrede isci yoxdursa xeta mesaji veirr ve proses menusuna qayidir.
                                         Eger varsa o iscinin hazirki melumatlarini (fullname, salary, position) ve 
                                         console-dan salary ve position ucun yeni deyerler teyin etmesi gozlenilir.
                                        (iscinin ancaq salary ve positionu editlene bilir)

 2.5 - Departamentden isci silinmesi - Parametr olaraq departament adi ve iscinin nomresi qebul edilir.Gonderilen adda departamentden gonderilen adda isci 
                                       departamentin isciler arrayinden silinir
                                       */