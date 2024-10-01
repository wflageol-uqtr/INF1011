using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class ObserverList
    {
        private List<Action> observers = new();

        public void Add(Action action) => observers.Add(action);
        public void Remove(Action action) => observers.Remove(action);
        public void Clear(Action action) => observers.Clear();

        public void Notify()
        {
            foreach (var action in observers)
                action();
        }
    }
}
