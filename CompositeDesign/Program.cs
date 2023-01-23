using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee() { Name = "Engin Demiroğ" };

            Employee salih = new Employee() { Name = "Salih Demiroğg" };

            engin.AddSubordiante(salih);

            Employee derin = new Employee() { Name = "Derin Demiroğ" };
            engin.AddSubordiante(derin);

            Contractor ali = new Contractor() { Name = "Ali" };
            derin.AddSubordiante(ali);

            Employee ahmet= new Employee() { Name = "Ahmet" };
            salih.AddSubordiante(ahmet);



            Console.WriteLine(engin.Name);
            foreach (Employee manager in engin)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson item in manager)
                {
                    Console.WriteLine(" {0}",item.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }

    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates=new List<IPerson>();

        public void AddSubordiante(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordiante(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
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
