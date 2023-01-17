using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T : Bullet
{
    //private List<T> _items = new List<T>();

    //public Pool(T template)
    //{
    //    _items.Add(template);
    //}

    //public T GetItem()
    //{
    //    foreach(T item in _items)
    //    {
    //        if (item.IsAvailable)
    //        {
    //            item.Activate();
    //            return item;
    //        }
    //    }

    //    T item = Instantiate(_items[0]);
    //    _items.Add(item);
    //}

    //private void Add(T item)
    //{
    //    _items.Add(item);
    //}
}
