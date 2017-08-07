using System;

namespace Paysafe.Common
{
    public class PermissionException : PaysafeException
    {
        public PermissionException()
            : base()
        {

        }

        public PermissionException(String message)
            : base(message)
        {

        }

        public PermissionException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
