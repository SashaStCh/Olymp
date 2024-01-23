using System;
using System.Collections.Generic;
using System.Text;

namespace Olymp
{
    class NotEnoughStudentsException : Exception
    {
        public NotEnoughStudentsException() : base("Недостаточно учеников для теста.")
        {

        }

        public NotEnoughStudentsException(int count)
            : base($"Недостаточно учеников для теста. Необходимо не менее {count}.")
        {
        }

        public NotEnoughStudentsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
