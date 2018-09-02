using System;
using CrossCutting.Authentication.Models;

namespace AuthenticationService.Exceptions
{
    [Serializable]
    class RegistrationException : Exception
    {
        public RegistrationException()
        {

        }

        public RegistrationException(AuthenticationModel registrationModel)
            : base($"There is already an entry with the same credentials. {registrationModel}")
        {

        }

    }
}