using System;

namespace Godep.DI
{
    /// <summary>
    /// Allows ContextInstaller to find and inject dependencies in classes
    /// </summary>
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