using System;
using System.Collections.Generic;

namespace FamilyStructure_2
{
    class Program
    {
    public    static List<string> GetNames(List<Person> Elements)
        {
            List<string> names = new List<string>();
            if (Elements.Count != 0)
            {
                foreach (Person elm in Elements)
                {
                    if (elm != null)
                        names.Add(elm.FullName);
                }
                return names;
            }
            else
                return null;

        }
    public    static void Print(List<Person> Elements)
        {
            if (Elements.Count != 0)
            {
                foreach (Person elm in Elements)
                {
                    if (elm != null)
                        Console.Write(elm.FullName + " ");
                }
            }
            else
                Console.Write("No Data Elments Found");
            Console.WriteLine();
        }

        #region Feilds_Family Ftructure 

        //level 1 of familyStructure 
      static  Person Mohamed = new Person("Mohamed");
      static  Person Ahmed = new Person("Ahmed");  
      static  Person Yousry = new Person("Yousry");
      static  Person khaled = new Person("khaled");
        // level 2 of familyStructure 
      static  Person Azziz = new Person("Azziz", Mohamed);
      static  Person Mona = new Person("Mona", Mohamed);

      static  Person Yousf = new Person("Yousf", Yousry);

     static   Person AzzizWife = new Person("AzzizWife");
        //level 3 of familyStructure 
      static      Person Egor = new Person("Egor", Mona);
       static     Person Ivan = new Person("Ivan", Mona);
       static     Person Youri = new Person("Youri", Mona);
     static   Person Bakar = new Person("Bakar", Azziz);
     static   Person AbdAlrhman = new Person("AbdAlrhman", Azziz);
     static   Person Ismail = new Person("Ismail", Azziz);
     static   Person Amal = new Person("Amal");
      static      Person Ebrahim = new Person("Ebrahim");
      static  Person Mechaeil = new Person("Mechaeil");
        #endregion
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
            Print(Mechaeil.GetMainParents());
            Print(Youri.GetMainParents());
            Print(Ivan.GetAllUncles());
            Print(Bakar.GetCousins());
            Print(Mona.GetInLaws());
            Print(Mona.GetMainParents());
            Print(Mona.GetMainParents());
            Print(Youri.GetCousins());
            Print(Youri.GetCousins());
            Console.ReadLine();
        }

    }
}