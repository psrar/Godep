using System;

namespace Godep.DI
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class InjectAttribute : Attribute
    {
        readonly public string Id = null;

        public InjectAttribute() { }

        public InjectAttribute(string id)
        {
            Id = id;
        }
    }
}