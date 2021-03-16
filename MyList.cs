using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class MyList<T> : IEnumerable<T>
    {
        private readonly T[] _list = new T[1];
        public MyList(T[] list)
        {
            List = list[1];
        }

        public T List { get; set; }
        public void Add(ref T[] array, T value, int index)
        {
            T[] newArray = new T[array.Length + 1];
            newArray[index] = value;
            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = index; i < array.Length; i++)
            {
                newArray[i + 1] = array[i];
            }
        }

        public void RemoveAt(ref T[] array, int index)
        {
            T[] newArray = new T[array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
            }

            array = newArray;
        }

        public void Sort<TVal>(TVal[] a)
        where TVal : IComparable<TVal>
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j].CompareTo(a[i]) < 0)
                    {
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            yield return (T)_list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return (T)_list.GetEnumerator();
        }

        public T[] AddRange<TVal>(T[] array1, T[] array2)
        {
            if (array1 == null)
            {
                throw new ArgumentNullException("array1");
            }

            if (array2 == null)
            {
                throw new ArgumentNullException("array2");
            }

            int oldLen = array1.Length;
            Array.Resize<T>(ref array1, array1.Length + array2.Length);
            Array.Copy(array1, 0, array1, oldLen, array2.Length);
            return array1;
        }

        public bool Remove(T item, int i)
        {
            var firstinstance = Array.IndexOf(_list, item);
            if (firstinstance != -1)
            {
                Remove(item, i);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
