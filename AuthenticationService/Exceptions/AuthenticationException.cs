using System;
using CrossCutting.Authentication.Models;

namespace CrossCutting.Exceptions
{
    [Serializable]
    class AuthenticationException : Exception
    {
        public AuthenticationException()
        {

        }

        public AuthenticationException(AuthenticationModel authmodel)
            : base($"The provided credentials do not match. {authmodel}")
        {

        }

    }
}