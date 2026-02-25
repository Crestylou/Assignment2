using System;
using System.IO;

public class Student
{
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
    public int Grade { get; set; }

    public Student(int id, string name, string course, int grade)
    {
        StudentID = id;
        Name = name;
        Course = course;
        Grade = grade;
    }

    public override string ToString()
    {
        return $"{StudentID},{Name},{Course},{Grade}";
    }
}
