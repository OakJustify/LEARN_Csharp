using System;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Finance.Student financeStudent = new Finance.Student();

            Academic.Student academicStudent = new Academic.Student();

            Console.WriteLine(financeStudent.Payment);
            Console.WriteLine(academicStudent.Name);
        }
    }
}

namespace Academic
{
    class Student
    {
        public string Name = "David";
    }
}

namespace Finance
{
    class Student
    {
        public decimal Payment = 10000;
    }
}
