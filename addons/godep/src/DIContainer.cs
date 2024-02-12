using System;
using System.Collections.Generic;

namespace Godep.DI
{
    /// <summary>
    /// A class that stores dependencies and selects them by the requested type or ID. <br></br>
    /// Nesting is supported, which means that if there is no dependency in a given container instance, the search will continue in the parent container.<br></br>
    /// To specify a parent container, use a special constructor or apply the InjectFrom() method
    /// </summary>
    public class DIContainer
    {
        private DIContainer parentContainer = null;
        private Dictionary<Type, object> container = new();
        private Dictionary<string, object> idContainer = new();

        public DIContainer() { }

        public DIContainer(DIContainer parentContainer)
        {
            this.parentContainer = parentContainer;
            container[typeof(DIContainer)] = this;
        }

        public void InjectFrom(DIContainer parentContainer)
        {
            this.parentContainer = parentContainer;
        }

        public T Get<T>()
        {
            container.TryGetValue(typeof(T), out var dep);
            if (dep == null && parentContainer != null)
                dep = parentContainer.Get<T>();
            return (T)dep ?? throw new Exception($"Dependency {typeof(T)} not found");
        }

        public object Get(Type type)
        {
            container.TryGetValue(type, out var dep);
            if (dep == null && parentContainer != null)
                dep = parentContainer.Get(type);
            return dep ?? throw new Exception($"Dependency {type} not found");
        }

        public T GetWithId<T>(string id)
        {
            idContainer.TryGetValue(id, out var dep);
            if (dep == null && parentContainer != null)
                dep = parentContainer.GetWithId<T>(id);

            if (dep == null)
                throw new Exception($"Dependency {typeof(T)} with id {id} not found");
            else if (dep is not T)
                throw new Exception($"Found dependency '{id}', but required type {typeof(T)} doesn't match type of this object: {dep.GetType()}");

            return (T)dep;
        }

        public object GetWithId(Type type, string id)
        {
            idContainer.TryGetValue(id, out var dep);
            if (dep == null && parentContainer != null)
                dep = parentContainer.GetWithId(type, id);

            if (dep == null)
                throw new Exception($"Dependency {type} with id {id} not found");
            else if (dep.GetType() != type)
                throw new Exception($"Found dependency '{id}', but required type {type} doesn't match type of this object: {dep.GetType()}");

            return dep;
        }

        public T Bind<T>(T instance, bool overwrite = false)
        {
            if (container.ContainsKey(typeof(T)) && !overwrite)
                throw new Exception($"Dependency {typeof(T)} has been bound already. If you want to overwrite it intentionally, specify the 'overwrite' parameter");

            container[typeof(T)] = instance;
            return instance;
        }

        public T BindWithId<T>(string id, T instance, bool overwrite = false)
        {
            if (idContainer.ContainsKey(id) && !overwrite)
                throw new Exception($"Dependency with id '{id}' has been bound already. If you want to overwrite it intentionally, specify the 'overwrite' parameter");

            idContainer[id] = instance;
            return instance;
        }
    }
}