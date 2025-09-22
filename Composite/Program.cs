using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
     class Program
    {
        static void Main(string[] args)
        {
            Employee furkan = new Employee { Name = "Furkan Ateş" };
            Employee bayram = new Employee { Name = "Bayram Ateş" };
            Employee saliha = new Employee { Name = "Saliha Ateş" };
            Employee muge = new Employee { Name = "Müge Ateş" };
            Employee eda = new Employee { Name = "Eda Ağkün" };

            Contractor tasiyici = new Contractor { Name = "Düğün Arabası" }; //2. kısım
            furkan.AddSubordinate(tasiyici);

            
            
            bayram.AddSubordinate(furkan);
            Employee merve = new Employee { Name = "Merve Ateş" };
            furkan.AddSubordinate(merve);
            furkan.AddSubordinate(muge);
            saliha.AddSubordinate(muge);
            merve.AddSubordinate(eda);
            Console.WriteLine(furkan.Name);
            foreach(Employee manager in furkan)
            {
                Console.WriteLine(manager.Name);
                foreach(Employee employee in manager)
                {
                    Console.WriteLine("   {0}   ",employee.Name);
                }
            }

            Console.ReadKey();


        }
    }

    public interface IPerson
    {
        string Name { get; set; }
    }


    class Contractor : IPerson
    {
        public string Name { get; set ; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();
        public string Name { get; set; }
        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach(var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }









}
