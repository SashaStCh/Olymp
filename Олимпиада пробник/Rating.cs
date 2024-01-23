using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ExcelDataReader;

namespace Olymp
{
    class Rating
    {
        public List<School> schools = new List<School>();
        public List<Student> students = new List<Student>();
        public void LoadFromExcel(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                ProcessRow(reader.GetString(0), Convert.ToByte(reader.GetValue(1)), reader.GetString(2));
                            }
                            catch (MaximumNumberOfStudentsException e)
                            {
                                throw e;
                            }
                            catch (WrongScoreException e)
                            {
                                throw e;
                            }
                            catch { }
                        }

                        if (students.Count < 5)
                        {
                            throw new NotEnoughStudentsException(5);
                        }
                        if (schools.Count >= 50)
                        {
                            throw new TooManySchoolsException(50);
                        }

                        // сортировка списка учеников по оценке
                        students.Sort((a, b) => b.Score - a.Score);
                        // найти максимальную среднюю оценку по школе
                        FindMaxAverageScore();
                        DeterminateWinners();
                        // вывод списка учеников
                        Console.WriteLine("\tРейтинговый список участников олимпиады:");
                        foreach (Student student in students)
                        {
                            Console.WriteLine(student.Surname + " " + student.Score + " " + student.SchoolName + " " + student.Status);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ProcessRow(string name, byte score, string schoolName)
        {
            // проверка на пустую строку
            if ((name == null) || (schoolName == null))
            {
                return;
            }
            Student student = new Student(name, score, schoolName);
            School school = schools.Find(s => s.Name == schoolName);
            if (school == null)
            {
                school = new School(schoolName);
                schools.Add(school);
            }
            school.AddStudent(student);
            students.Add(student);

        }
        private void FindMaxAverageScore()
        {
            float maxAverageScore = -1;
            School schoolMaxAverageScore = default;
            foreach (School school in schools)
            {
                if (maxAverageScore < school.FindAverageScore())
                {
                    maxAverageScore = school.FindAverageScore();
                    schoolMaxAverageScore = school;
                }
            }
            string message = $"Школа с максимальным средним баллом: {schoolMaxAverageScore.Name}\tСредний балл: {maxAverageScore}\n";
            Console.Write(message);
            Console.WriteLine("\tУченики этой школы:");
            schoolMaxAverageScore.WriteStudents();
        }
        private void DeterminateWinners()
        {
            // метод должен обрабатывать отсортированный по убыванию список учеников
            int i = 0;
            if (students[0].Score >= 70)
            {
                students[0].Status = "Победитель";
                i++;
                while ((i < students.Count) && (students[i].Score == students[0].Score))
                {
                    students[i].Status = "Победитель";
                    i++;
                }
            }
            for (int j = 0; (i < students.Count) && (students[i].Score >= 50) && (j < 4); j++, i++)
            {
                students[i].Status = "Призёр";
                while ((i + 1 < students.Count) && (students[i + 1].Score == students[i].Score))
                {
                    students[i + 1].Status = "Призёр";
                    i++;
                }
            }
        }

    }
}
