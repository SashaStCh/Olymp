using System;
using System.Collections.Generic;
using System.Text;

namespace Olymp
{
    class MaximumNumberOfStudentsException : Exception
    {
        public MaximumNumberOfStudentsException() : base("В олимпиаде не может участвовать более 5-ти учеников от одной школы. Проверьте данные!")
        {
            
        }

        public MaximumNumberOfStudentsException(string message)
            : base(message)
        {

        }

        public MaximumNumberOfStudentsException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
