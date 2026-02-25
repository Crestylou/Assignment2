using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Step 1: Create student objects
        List<Student> students = new List<Student>()
        {
            new Student(101, "John", "BSIT", 89),
            new Student(102, "Maria", "BSCS", 92),
            new Student(103, "Paul", "BSIT", 75),
            new Student(104, "Ana", "BSCS", 85),
            new Student(105, "Mark", "BSIT", 90)
        };

        // Step 2: Write students to students.txt
        string filePath = "students.txt";
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (var student in students)
                sw.WriteLine(student.ToString());
        }

        Console.WriteLine("students.txt created and data written.\n");

        // Step 3: Read students.txt and convert to List<Student>
        string[] lines = File.ReadAllLines(filePath);
        List<Student> studentList = new List<Student>();
        foreach (var line in lines)
        {
            var parts = line.Split(',');
            studentList.Add(new Student(
                int.Parse(parts[0]),
                parts[1],
                parts[2],
                int.Parse(parts[3])
            ));
        }

        // Step 4: LINQ queries (Method Syntax)

        // 4a. Students with Grade > 85
        var highGrades = studentList.Where(s => s.Grade > 85);
        Console.WriteLine("Students with Grade > 85:");
        foreach (var s in highGrades)
            Console.WriteLine($"{s.Name} - {s.Grade}");

        // 4b. Sorted by Grade Descending
        var sortedGrades = studentList.OrderByDescending(s => s.Grade);
        Console.WriteLine("\nSorted by Grade (Descending):");
        foreach (var s in sortedGrades)
            Console.WriteLine($"{s.Name} - {s.Grade}");

        // 4c. Only student names
        var namesOnly = studentList.Select(s => s.Name);
        Console.WriteLine("\nStudent Names:");
        foreach (var n in namesOnly)
            Console.WriteLine(n);

        // 4d. Average Grade
        var avgGrade = studentList.Average(s => s.Grade);
        Console.WriteLine($"\nAverage Grade: {avgGrade:F2}");
    }
}