using System;

namespace RedWalker.Core.Exceptions;

public class ValidationException: SystemException
{
    public  ValidationException (string message) : base(message) {}
}