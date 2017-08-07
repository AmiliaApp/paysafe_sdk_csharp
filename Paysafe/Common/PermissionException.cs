using System;

namespace Paysafe.Common
{
    public class PermissionException : PaysafeException
    {
        public PermissionException()
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
