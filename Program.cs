using System;

namespace reflectionProj
{
     class Program
    {
        static void Main(string[] args)
        {
            Coder RegularRyan = new Coder();
            var BillLumbergh = new ProjectManager();

             //Better Way with reflection
            var MyBetterEmployee = new BetterEmployee(RegularRyan);
            MyBetterEmployee.RearWork();

            MyBetterEmployee = new BetterEmployee(BillLumbergh);
            MyBetterEmployee.RearWork();
        }
    }

    public interface IEmployee
    {
        public EnumEmployeeClass EmployeeClass { get; }
        public void Work(){}
    }

    public abstract class Employee : IEmployee
    {
        public abstract EnumEmployeeClass EmployeeClass { get; }

        public void Work()
        {
            Console.WriteLine("Employee Works");
        }

        public void TakeBreak()
        {
            Console.WriteLine("Employee Take Breaks");
        }

    }

    class CFO : Employee
    {
        public override EnumEmployeeClass EmployeeClass { get { return EnumEmployeeClass.CFO; } }

        public void Quits()
        {
            Console.WriteLine("CFO Quits");
        }
    }

    class ProjectManager : Employee
    {
        public override EnumEmployeeClass EmployeeClass { get { return EnumEmployeeClass.CFO; } }

        public void Quits()
        {
            Console.WriteLine("Project Manager Quits");
        }
    }

    class Salesperson : Employee
    {
        public override EnumEmployeeClass EmployeeClass { get { return EnumEmployeeClass.CFO; } }

        public void Quits()
        {
            Console.WriteLine("Salesperson Quits");
        }
    }

    class QA : Employee
    {
        public override EnumEmployeeClass EmployeeClass { get { return EnumEmployeeClass.QA; } }
    }

    class Coder : Employee
    {
        public override EnumEmployeeClass EmployeeClass { get { return EnumEmployeeClass.Coder; } }
    }

    class BA : Employee
    {
        public override EnumEmployeeClass EmployeeClass { get { return EnumEmployeeClass.BA; } }
    }

    public enum EnumEmployeeClass
    {
        CFO,
        Coder,
        BA,
        QA,
        ProjectManager

    }
}
