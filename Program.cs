﻿using System;
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

            foreach (Department item in HRManager.Departments)
            {
                System.Console.WriteLine(item.Name);
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