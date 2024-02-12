using System.ComponentModel.Design;
using System;

namespace Godep.DI
{
    public class DIContainer
    {
        private DIContainer parentContainer = null;
        private ServiceContainer container = new();

        public DIContainer() { }

        public DIContainer(DIContainer parentContainer)
        {
            this.parentContainer = parentContainer;
        }

        public T Get<T>()
        {
            T dep = (T)container.GetService(typeof(T));
            if (dep == null && parentContainer != null)
                dep = parentContainer.Get<T>();
        return dep ?? throw new Exception($"Dependency {typeof(T)} not found");
        }

        public object Get(Type type)
        {
            object dep = container.GetService(type);
            if (dep == null && parentContainer != null)
                dep = parentContainer.Get(type);
            return dep ?? throw new Exception($"Dependency {type} not found");
        }

        public T Bind<T>(T instance)
        {
            container.AddService(typeof(T), instance);
            return instance;
        }

        public void InjectFrom(DIContainer parentContainer)
        {
            this.parentContainer = parentContainer;
        }
    }
}