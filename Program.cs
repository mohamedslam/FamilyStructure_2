using FamilyStructure_2.Class;
using System;
using System.Collections.Generic;

namespace FamilyStructure_2
{
    class Program
    {

        //level 1 of familyStructure 
        static Person Mohamed = new Person("Mohamed");
        static Person Ahmed = new Person("Ahmed");
        static Person Yousry = new Person("Yousry");
        static Person khaled = new Person("khaled");
        // level 2 of familyStructure 
        static Person Azziz = new Person("Azziz", Mohamed);
        static Person Mona = new Person("Mona", Mohamed);

        static Person Yousf = new Person("Yousf", Yousry);

        static Person AzzizWife = new Person("AzzizWife");
         
        //static Person Egor = new Person("Egor", Mona);
        static Person Ivan = new Person("Ivan", Mona);
        static Person Youri = new Person("Youri", Mona);
        static Person Bakar = new Person("Bakar", Azziz);
    
        static Person Amal = new Person("Amal");
        static Person Ebrahim = new Person("Ebrahim");
        static Person Mechaeil = new Person("Mechaeil");


        public static void Operations()
        {
            Person.Married(Mohamed, Ahmed);
            Person.Married(Yousry, khaled);
            Person.Married(Mona, Yousf);
            Person.Married(Azziz, AzzizWife);
            Person.Married(Amal, Amal);
            Person.Married(Amal, Ebrahim);
            Person.Married(Amal, Mechaeil);
        }

        static void Main(string[] args)
        {

            Operations();
            ///////Printing Data
            ClsOperation.Print(Mechaeil.GetMainParents());
            ClsOperation.Print(Youri.GetMainParents());
            ClsOperation.Print(Ivan.GetAllUncles());
            ClsOperation.Print(Bakar.GetCousins());
            ClsOperation.Print(Mona.GetInLaws());
            ClsOperation.Print(Mona.GetMainParents());
            ClsOperation.Print(Mona.GetMainParents());
            ClsOperation.Print(Youri.GetCousins());
            ClsOperation.Print(Youri.GetCousins());
            Console.ReadLine();
        }

    }
}