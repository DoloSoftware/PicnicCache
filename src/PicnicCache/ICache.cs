﻿//The MIT License (MIT)
//https://github.com/DoloSoftware/PicnicCache/blob/master/LICENSE

using System;
using System.Collections.Generic;

namespace PicnicCache
{
    public interface ICache<TKey, TValue> where TValue : class, new()
    {
        /// <summary>
        /// Clear the cache.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Fetch item by key.
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="del">Func to get the item if it's not already in the cache.</param>
        /// <returns>Item</returns>
        TValue Fetch(TKey key, Func<TValue> del);

        /// <summary>
        /// Fetch all items.
        /// </summary>
        /// <param name="del">Func to get all items if they have not already been cached.</param>
        /// <returns>Items</returns>
        IEnumerable<TValue> FetchAll(Func<IEnumerable<TValue>> del);

        /// <summary>
        /// Set the item state to deleted.
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <returns>True if item was in cache otherwise false.</returns>
        bool Delete(TKey key);

        /// <summary>
        /// Set the item state to deleted by value.
        /// </summary>
        /// <param name="value">Item Key</param>
        /// <returns>True if item was in cache otherwise false.</returns>
        bool Delete(TValue value);

        /// <summary>
        /// Save all items from the cache.
        /// </summary>
        /// <param name="saveDelegate">Action to update, add and delete all CacheItems.</param>
        void Save(Action<IEnumerable<CacheItem<TValue>>> saveDelegate);

        /// <summary>
        /// Save all items from the cache.
        /// </summary>
        /// <param name="updateDelegate">Action to update the cached items</param>
        /// <param name="addDelegate">Action to add the cached items</param>
        /// <param name="deleteDelegate">Action to delete the cached items</param>
        void Save(Action<IEnumerable<TValue>> updateDelegate, Action<IEnumerable<TValue>> addDelegate, Action<IEnumerable<TValue>> deleteDelegate);

        /// <summary>
        /// Save all items from the cache.
        /// </summary>
        /// <param name="updateAddDelegate">Action to update and add the cached items.</param>
        /// <param name="deleteDelegate">Action to delete the cached items.</param>
        void Save(Action<IEnumerable<TValue>> updateAddDelegate, Action<IEnumerable<TValue>> deleteDelegate);

        /// <summary>
        /// Update the cached item or add it to the cache.
        /// </summary>
        /// <param name="value">Value to update or add.</param>
        void Update(TValue value);

        /// <summary>
        /// Update the cached items or add them to the cache.
        /// </summary>
        /// <param name="values">Values to update or add.</param>
        void Update(IEnumerable<TValue> values);
    }
}