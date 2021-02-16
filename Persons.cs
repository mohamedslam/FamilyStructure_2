using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FamilyStructure_2
{
    class Person
    {

        #region Feilds

        public string FullName { get; }
        private Person Husband { get; set; }
        private Person ParantRecord { get; }

        private List<Person> MainParant_list = new List<Person>();
        private List<Person> Parant_Child_list = new List<Person>();

        #endregion

        #region Methods
        public Person(string name, Person _parent = null, Person husspand = null)
        {
            FullName = name;
            ParantRecord = _parent;
            Husband = husspand;

            if (_parent != null)
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
            List<Person> Brothers_list = new List<Person>();
            if (ParantRecord != null)
            {
                foreach (Person parent in GetMainParents())
                {
                    foreach (Person Brothers in parent.GetAllChilds())
                    {
                        if (Brothers != null)
                        {
                            if (Brothers != this)
                            {
                                if (!Brothers_list.Contains(Brothers))
                                    Brothers_list.Add(Brothers);
                            }
                        }

                    }
                }
                return Brothers_list;
            }
            else
                return null;

        }

        public List<Person> GetAllUncles()
        {
            List<Person> AllUncles_list = new List<Person>();
            if (ParantRecord != null)
            {
                foreach (Person parent in this.GetMainParents())
                {
                    if (parent.ParantRecord != null)
                    {
                        foreach (Person uncle in parent.GetBrothersAndSisters())
                        {
                            if (uncle != null)
                            {
                                if (!AllUncles_list.Contains(uncle))
                                    AllUncles_list.Add(uncle);
                                if (uncle.Husband != null)
                                {
                                    if (!AllUncles_list.Contains(uncle.Husband))
                                        AllUncles_list.Add(uncle.Husband);
                                }
                            }
                        }
                    }
                }
                return AllUncles_list;
            }
            else
                return null;
        }

        public List<Person> GetCousins()
        {
            List<Person> cousins_list = new List<Person>();
            if (ParantRecord != null)
            {
                foreach (Person uncle in GetAllUncles())
                {
                    if (uncle != null)
                    {
                        foreach (Person cousine in uncle.GetAllChilds())
                        {
                            if (cousine != null)
                            {
                                if (!cousins_list.Contains(cousine))
                                    cousins_list.Add(cousine);
                            }
                        }
                    }

                }
                return cousins_list;
            }
            else
                return null;
        }

        public List<Person> GetInLaw()
        {
            List<Person> inlaw_list = new List<Person>();
            if (Husband != null)
            {
                if (Husband.ParantRecord != null)
                {
                    foreach (Person inlaw in Husband.GetMainParents())
                    {
                        if (inlaw != null)
                            inlaw_list.Add(inlaw);
                    }
                }
                return inlaw_list;
            }
            else
                return null;
        }

        public static void Married(Person a, Person b)
        {
            if (a == b)
                Console.WriteLine(a.FullName + " Its Not Logical");
            else if (a.Husband != null)
                Console.WriteLine(a.FullName + " has a Husband - " + a.Husband.FullName);
            else if (b.Husband != null)
                Console.WriteLine(b.FullName + " has a Husband - " + b.Husband.FullName);
            else
            {
                a.Husband = b;
                b.Husband = a;
            }
        }

        #endregion
    }
}