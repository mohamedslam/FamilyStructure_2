using System;
using System.Collections.Generic;

namespace FamilyStructure_2
{
    class Program
    {
        static List<string> GetNames(List<Person> Elements)
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
        static void PrintNames(List<Person> Elements)
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
        static void Main(string[] args)
        {

            //<<<<<<<<<<<< Family Ftructure >>>>///////////////////////

            //level 1 of familyStructure 
            Person Mohamed = new Person("Mohamed" );
            Person Ahmed = new Person("Ahmed");
            Person.Married(Mohamed, Ahmed);

            Person Yousry = new Person("Yousry");
            Person khaled = new Person("khaled");

            Person.Married(Yousry, khaled);

            // level 2 of familyStructure 
            Person Azziz = new Person("Azziz", Mohamed);
            Person Mona = new Person("Mona", Mohamed);

            Person Yousf = new Person("Yousf", Yousry);

            Person AzzizWife = new Person("AzzizWife");

            Person.Married(Mona, Yousf);
            Person.Married(Azziz, AzzizWife);

            //level 3 of familyStructure 
            Person Egor = new Person("Egor", Mona);
            Person Ivan = new Person("Ivan", Mona);
            Person Youri = new Person("Youri", Mona);

            Person Bakar = new Person("Bakar", Azziz);
            Person AbdAlrhman = new Person("AbdAlrhman", Azziz);
            Person Ismail = new Person("Ismail", Azziz);
            


            /////////////////////////// testing Structure//////////////////////////////////
            ///
            Person Amal = new Person("Amal");
            Person.Married(Amal, Amal);

            Person Ebrahim = new Person("Ebrahim");
            Person.Married(Amal, Ebrahim);
            Person Mechaeil = new Person("Mechaeil");
            Person.Married(Amal, Mechaeil);


            ///////Printing Data
            PrintNames(Mechaeil.GetMainParents());
            PrintNames(Youri.GetMainParents());
            PrintNames(Ivan.GetAllUncles());
            PrintNames(Bakar.GetCousins());
            PrintNames(Mona.GetInLaw());
            PrintNames(Mona.GetMainParents());
            PrintNames(Mona.GetMainParents());
            PrintNames(Youri.GetCousins());
            PrintNames(Youri.GetCousins());



            Console.ReadLine();
        }

    }
}