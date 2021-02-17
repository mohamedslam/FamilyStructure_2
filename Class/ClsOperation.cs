using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyStructure_2.Class
{
  public  class ClsOperation
    {
       internal  static List<string> GetNames(List<Person> Elements)
        {
            var names = new List<string>();
            if (Elements.Count > 0)
                foreach (var elm in Elements)
                    if (elm != null)
                        names.Add(elm.FullName);

            return names;
        }
       internal  static void Print(List<Person> Elements)
        {
            if (Elements.Count > 0)            
                foreach (var elm in Elements)                
                    if (elm != null)
                        Console.Write(elm.FullName + " | "); 
            else
                Console.Write("No Data Elments Found\n");

        }

        #region Feilds_Family Ftructure 

        #endregion
    
    }
}
