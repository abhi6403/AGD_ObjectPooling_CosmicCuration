using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Utilities
{
    public class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> _pooledItems = new List<PooledItem<T>>();

        protected T GetItem()
        {
            if (_pooledItems.Count > 0)
            {
                PooledItem<T> item = _pooledItems.Find(item=>!item.isUsed);

                if (item != null)
                {
                    item.isUsed = true;
                    return item.Item;
                }
            }

            return CreateNewPooledItems();
        }

        private T CreateNewPooledItems()
        {
           PooledItem<T> newItem = new PooledItem<T>();
           newItem.Item = CreateItems();
           newItem.isUsed = true;
           _pooledItems.Add(newItem);
           return newItem.Item;
        }

        protected virtual T CreateItems()
        {
            throw new System.NotImplementedException("Child class did not implement create item");
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }
}
