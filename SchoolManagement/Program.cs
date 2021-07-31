using System;

namespace SchoolManagement
{
    class Program
    {
        static void Main()
        {
            Program.PrintOptions();
        }

        public static void PrintOptions()
        {
            Console.Clear();
            Console.WriteLine("Welcome to school management system");
            Console.WriteLine("1. Manage student details");
            Console.WriteLine("2. Manage faculty details");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter the respective number to perform the actions....");
            string option = Console.ReadLine();
            Program.OperationSelector(option);
        }

       static  void OperationSelector(string option)
        {
            bool  isValidOption = Int32.TryParse(option, out int operationIndex);
            if(!isValidOption)
            {
                Console.Clear();
                Console.WriteLine("Invalid Options");
                Program.PrintOptions();
            }
            switch (operationIndex)
            {
                case 1:
                    StudentService studentService = StudentService.createInstance();
                    studentService.ManageStudentDetails();
                    break;
                case 2:
                    FacultyService facultyService = new FacultyService();
                    facultyService.ManageFacultyService();
                    break;
                case 3:
                    Console.WriteLine("Good bye...");
                    break;                
            }
        }
        
    }
}
