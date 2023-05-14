using Ldap.Dtos;
using Ldap.Models;
using System;

namespace Ldap
{
    public class Ldap
    {
        private readonly string _host;

        public Ldap(string host = "http://localhost:80")
        {
            _host = host;
        }

        public ApiResponseModel<LdapEmployeeModel> Login(LdapLoginParameterDto loginParameter)
        {
            return new ApiResponseModel<LdapEmployeeModel>();
        }
    }
}
