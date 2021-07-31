using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class StudentService
    {
        public int count;
        static List<Student> students;
        static bool isInstanceCreated;
        static StudentService SingleTonInstance;

        private StudentService()
        {

        }

        public static StudentService createInstance()
        {
            if (!isInstanceCreated)
            {
                students = new List<Student>();
                SingleTonInstance = new StudentService();
                isInstanceCreated = true;
            }

            return SingleTonInstance;
        }
        public void ManageStudentDetails()
        {
            PrintStudentManageOptions();
        }
        public void PrintStudentManageOptions()
        {
            Console.Clear();
            Console.WriteLine("1.Add student details");
            Console.WriteLine("2.Edit student details");
            Console.WriteLine("3.Delete student details");
            Console.WriteLine("4.View student details");
            Console.WriteLine("5.Back");
            Console.WriteLine("6.Exit");
            string option = Console.ReadLine();
            RedirectByOption(option);
        }

        private void RedirectByOption(string option)
        {
            bool isValidOption = Int32.TryParse(option, out int operationIndex);
            if (!isValidOption)
            {
                Console.Clear();
                Console.WriteLine("Invalid Options");
                PrintStudentManageOptions();
            }
            switch (operationIndex)
            {
                case 1:
                    AddStudentDetails();
                    break;
                case 2:
                    EditStudentDetails();
                    break;
                case 4:
                    ViewStudentDetails();
                    break;
                case 3:
                    DeleteStudentDetails();
                    break;
                case 5:
                    Program.PrintOptions();
                    break;
                case 6:
                    Console.WriteLine("Good bye...");
                    break;
            }
        }
        public void AddStudentDetails()
        {
            Console.Clear();
            string AddOneMoreStudent;
            do
            {
                Student student = new Student();
                Console.WriteLine("Student Firstname:");
                student.Name = Console.ReadLine();
                Console.WriteLine("Student Class");
                student.Class = Console.ReadLine();
                Console.WriteLine("Student Father/Mother name");
                student.ParentName = Console.ReadLine();
                Console.WriteLine("Student Father/Mother phone number");
                student.ParentContactNo = Console.ReadLine();

                student.Id = ++count;
                students.Add(student);

                Console.WriteLine("Student details saved Successfully");

                Console.WriteLine("Do you want to add one more detais (y/n)");
                AddOneMoreStudent = Console.ReadLine().ToLower();
            }
            while (AddOneMoreStudent == "y");

            PrintStudentManageOptions();
        }

        public void EditStudentDetails()
        {
            Console.WriteLine("Enter the id of the student");
            string id = Console.ReadLine();
            bool isValidId = Int32.TryParse(id, out int studentId);
            if (!isValidId && studentId <= 0 && studentId >= students.Count)
            {
                Console.WriteLine("Entered the wrong Id");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                EditStudentDetails();
            }
            else
            {
                var student = students[studentId - 1];
                Console.WriteLine("Student Firstname:");
                student.Name = Console.ReadLine();
                Console.WriteLine("Student Class");
                student.Class = Console.ReadLine();
                Console.WriteLine("Student Father/Mother name");
                student.ParentName = Console.ReadLine();
                Console.WriteLine("Student Father/Mother phone number");
                student.ParentContactNo = Console.ReadLine();                                

                Console.WriteLine("Student details modified Successfully");
                Console.WriteLine("Press any key to go back");
                PrintStudentManageOptions();

            }

        }

        public void DeleteStudentDetails()
        {
            Console.Clear();
            Console.WriteLine("Enter the student Id to delete");
            string id = Console.ReadLine();
            bool isValidId = Int32.TryParse(id, out int studentId);

            if (!isValidId || studentId<=0 || studentId > students.Count)
            {
                Console.WriteLine("Entered the wrong Id");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                
                DeleteStudentDetails();
            }
            else
            {
                Console.WriteLine("Student " + students[studentId - 1].Name + "delete successfully");
                students.RemoveAt(studentId - 1);
                
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            PrintStudentManageOptions();
        }

        public void ViewStudentDetails()

        {
            Console.Clear();
            foreach (var student in students)
            {
                Console.WriteLine("Student id: " + student.Id);
                Console.WriteLine("Student name: " + student.Name);
                Console.WriteLine("Student class: " + student.Class);
                Console.WriteLine("Student parent name: " + student.ParentName);
                Console.WriteLine("Student parent phone no: " + student.ParentContactNo);
                Console.WriteLine("*********************************************");
            }

            Console.WriteLine("Click any key to go back");
            Console.ReadKey();
            PrintStudentManageOptions();
        }
    }
}
