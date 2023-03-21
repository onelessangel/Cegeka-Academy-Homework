using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo.SetImplementation
{
    class Set<T>
    {
        private List<T> values { get; set; }

        public Set()
        {
            values = new List<T>();
        }

        public Set(Set<T> set)
        {
            values = set.values;
        }

        public Set(List<T> values)
        {
            this.values = values;
        }

        public void Insert(T item)
        {
            try
            {
                values.Single(i => i.Equals(item));
            }
            catch (Exception ex)
            {
                values.Add(item);
            }            
        }

        public void Remove(T item)
        {
            values.Remove(item);
        }

        public bool Contains(T item)
        {
            return values.Contains(item);
        }

        public void Print()
        {
            foreach (T item in values)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public Set<T> Merge(Set<T> other)
        {
            foreach (var item in other.values)
            {
                Insert(item);
            }

            return this;
        }

        public Set<T> Filter(Func<T, bool> lambda)
        {
            List<T> subset = values.Where(lambda).ToList();

            return new Set<T>(subset);
        }
    }
}
