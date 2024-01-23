using System;
using System.Collections.Generic;
using System.Text;

namespace Olymp
{
    class WrongScoreException : Exception
    {
        public WrongScoreException() : base("Оценка ученика введена некорректно.")
        {

        }

        public WrongScoreException(string message)
            : base(message)
        {

        }

        public WrongScoreException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
