using System;
using System.Collections.Generic;
using System.Text;

namespace Olymp
{
    class TooManySchoolsException : Exception
    {
        public TooManySchoolsException() : base("В олимпиаде участвует слишком много школ.")
        {

        }

        public TooManySchoolsException(int count)
            : base($"В олимпиаде участвует слишком много школ. Необходимо не более {count}.")
        {
        }

        public TooManySchoolsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
