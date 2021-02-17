using System;
using System.Collections.Generic;
namespace FamilyStructure_2
{
    class Person
    {

        #region Feilds
         
          public string FullName { get; set; }
          Person Husband { get; set; }
          Person ParantRecord { get; set; }

          List<Person> MainParant_list = new List<Person>();
          List<Person> Parant_Child_list = new List<Person>(); 

        #endregion

        #region Methods
   
        public Person(string FullName, Person ParantRecord = null, Person Husband = null)
        {
            this.FullName = FullName;
            this.ParantRecord = ParantRecord ;
            this.Husband = Husband;

            if ( ParantRecord !=  null)
            {
                ParantRecord.Parant_Child_list.Add(this);
                MainParant_list.Add(ParantRecord);
                if (ParantRecord.Husband != null)
                {
                    ParantRecord.Husband.Parant_Child_list.Add(this);
                    MainParant_list.Add(ParantRecord.Husband);
                }
            }
        }

        public List<Person> GetAllChilds()
        {
            return Parant_Child_list;
        }

        public List<Person> GetMainParents()
        {
            return MainParant_list;
        }

        public List<Person> GetBrothersAndSisters()
        {
            var Brothers_list = new List<Person>();
            if (ParantRecord != null)           
                foreach (var p in GetMainParents())                
                    foreach (var Brothers in p.GetAllChilds())                    
                        if (Brothers != null)                       
                            if (Brothers != this)                            
                                if (!Brothers_list.Contains(Brothers))
                                    Brothers_list.Add(Brothers);
            
                return Brothers_list;

        }

        public List<Person> GetAllUncles()
        {
            var AllUncles_list = new List<Person>();
            if (ParantRecord != null)           
                foreach (var parent in GetMainParents())                
                    if (parent.ParantRecord != null)                   
                        foreach (var uncle in parent.GetBrothersAndSisters())                        
                            if (uncle != null)
                            {
                                if (!AllUncles_list.Contains(uncle))
                                    AllUncles_list.Add(uncle);
                                if (uncle.Husband != null)                                
                                    if (!AllUncles_list.Contains(uncle.Husband))
                                        AllUncles_list.Add(uncle.Husband);                                
                            }
                        
                   
               
          
            return AllUncles_list;
        }

        public List<Person> GetCousins()
        {
            var cousins_list = new List<Person>();
            if (ParantRecord != null)           
                foreach (var uncle in GetAllUncles())                
                    if (uncle != null)                   
                        foreach (var cousine in uncle.GetAllChilds())                        
                            if (cousine != null)                          
                                if (!cousins_list.Contains(cousine))
                                    cousins_list.Add(cousine);
                           
                        
                    

                
                
            
            return cousins_list;
        }

        public List<Person> GetInLaws()
        {
           var inlaw_list = new List<Person>();
            if (Husband != null)           
                if (Husband.ParantRecord != null)                
                    foreach (var  Inlaw in Husband.GetMainParents())                    
                        if (Inlaw != null)
                            inlaw_list.Add(Inlaw);
                    
                
               
           
            return inlaw_list;
        }

        public static void Married(Person Man, Person Woman)
        {
             if (Man.Husband !=null)
                Console.WriteLine(Man.FullName + " has a Husband - " + Woman.Husband.FullName);
            else if (Woman.Husband != null)
                Console.WriteLine(Woman.FullName + " has a Husband - " + Woman.Husband.FullName);
            else
            {
                Man.Husband = Woman;
                Woman.Husband = Man;
            }
        }

        #endregion

    }
}