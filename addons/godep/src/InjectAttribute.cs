using System;

namespace Godep.DI
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class InjectAttribute : Attribute
    {
    }
}