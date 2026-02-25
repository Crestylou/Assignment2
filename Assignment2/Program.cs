using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment2
{
    class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int Grade { get; set; }

        public Student(int studentID, string name, string course, int grade)
        {
            StudentID = studentID;
            Name = name;
            Course = course;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{StudentID},{Name},{Course},{Grade}";
        }
    }

    class Program
    {
        static void Main()
        {
            string fileName = "students.txt";

            // Task 1: Create and write student data
            List<Student> students = new List<Student>()
            {
                new Student(101, "John", "BSIT", 89),
                new Student(102, "Maria", "BSCS", 92),
                new Student(103, "Paul", "BSIT", 75),
                new Student(104, "Ana", "BSCS", 85),
                new Student(105, "Mark", "BSIT", 90)
            };

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var s in students)
                {
                    writer.WriteLine(s);
                }
            }

            Console.WriteLine("Student records saved to students.txt\n");

            // Task 2: Read file and use LINQ
            List<Student> readStudents = File.ReadAllLines(fileName)
                .Select(line => line.Split(','))
                .Select(parts => new Student(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])
                ))
                .ToList();

            Console.WriteLine("Students with Grade > 85:");
            readStudents.Where(s => s.Grade > 85)
                        .ToList()
                        .ForEach(s => Console.WriteLine($"{s.Name} - {s.Grade}"));

            Console.WriteLine("\nSorted by Grade (Descending):");
            readStudents.OrderByDescending(s => s.Grade)
                        .ToList()
                        .ForEach(s => Console.WriteLine($"{s.Name} - {s.Grade}"));

            Console.WriteLine("\nStudent Names:");
            readStudents.Select(s => s.Name)
                        .ToList()
                        .ForEach(name => Console.WriteLine(name));

            Console.WriteLine($"\nAverage Grade: {readStudents.Average(s => s.Grade):F2}");
        }
    }
}
