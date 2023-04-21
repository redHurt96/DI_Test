using System;
using System.Collections.Generic;

namespace GameSystem
{
    public interface IGameLocator
    {
        void AddService(object service);

        void AddServices(IEnumerable<object> services);

        void RemoveService(object service);

        T GetService<T>();
    }

    public sealed class GameLocator : IGameLocator
    {
        private readonly List<object> services = new();

        public void AddServices(IEnumerable<object> services)
        {
            this.services.AddRange(services);
        }

        public void AddService(object service)
        {
            this.services.Add(service);
        }

        public void RemoveService(object service)
        {
            this.services.Remove(service);
        }

        public T GetService<T>()
        {
            foreach (var service in this.services)
            {
                if (service is T result)
                {
                    return result;
                }
            }

            throw new Exception($"Service of type {typeof(T)} is not found!");
        }
    }
}