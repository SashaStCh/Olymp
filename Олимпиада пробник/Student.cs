using System;
using System.Collections.Generic;
using System.Text;

namespace Olymp
{
    class Student
    {
        public Student(string surname, int score, string schoolName)
        {
            this.Surname = surname;
            this.Score = score;
            this.SchoolName = schoolName;
        }

        public string Surname { get; set; }
        public string Status { get; set; } = "Участник";

        private int score;
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.score = value;
                }
                else
                {
                    throw new WrongScoreException();
                }
                
            }
        }
        public string SchoolName { get; set; }
    }
}
