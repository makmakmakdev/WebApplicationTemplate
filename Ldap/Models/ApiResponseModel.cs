using System;
using System.Collections.Generic;
using System.Text;

namespace Ldap.Models
{
    public class ApiResponseModel<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
