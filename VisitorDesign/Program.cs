using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager engin = new Manager() { Name = "Engin", Salary = 1000 };
            Manager salih = new Manager() { Name = "Salih", Salary = 900 };

            Worker derin=new Worker() { Name="Derin",Salary= 800 };
            Worker ali=new Worker() { Name="Ali",Salary= 800 };

            engin.Subordinates.Add(salih);
            salih.Subordinates.Add(derin);
            salih.Subordinates.Add(ali);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(engin);

            PayrollVisitor payrollVisitor = new PayrollVisitor();
            Payrise payrise=new Payrise();

            organisationalStructure.Accept(payrollVisitor);
            organisationalStructure.Accept(payrise);

            Console.ReadLine();

        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase Employee;

        public OrganisationalStructure(EmployeeBase employeeBase)
        {
            Employee = employeeBase;
        }

        public void Accept(VisitorBase visitorBase)
        {
            Employee.Accept(visitorBase);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitorBase);
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates=new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get;set; }
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitorBase);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitorBase)
        {
            visitorBase.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary*(decimal) 1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary*(decimal)1.2);
        }
    }
}
