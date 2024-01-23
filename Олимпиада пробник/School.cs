using System;
using System.Collections.Generic;
using System.Text;

namespace Olymp
{
    class School
    {
        public string Name { get; set; }
        public List<Student> students = new List<Student>();

        public School (string name)
        {
            this.Name = name;
        }

        public void AddStudent(Student student)
        {
            if (students.Count < 5)
            {
                students.Add(student);
            }
            else
            {   
                throw new MaximumNumberOfStudentsException();
            }
        }
        public float FindAverageScore()
        {
            float averageScore;
            averageScore = 0;
            foreach (Student student in students)
            {
                averageScore += student.Score;
            }
            averageScore /= students.Count;
            return averageScore;
        }
        public void WriteStudents()
        {
            students.Sort((a, b) => b.Score - a.Score);
            foreach (Student student in students)
            {
                Console.WriteLine(student.Surname + " " + student.Score + " " + student.SchoolName);
            }
            Console.WriteLine();
        }
    }
}
