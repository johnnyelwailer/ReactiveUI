﻿using System;
using NLog;

namespace ReactiveUI.Serialization
{
    /// <summary>
    /// NullStorageEngine is a test implementation of IStorageEngine that
    /// always returns zero results
    /// </summary>
    public class NullStorageEngine : IStorageEngine
    {
        static readonly Logger log = LogManager.GetCurrentClassLogger();

        public T Load<T>(Guid ContentHash) where T : ISerializableItem
        {
            log.Debug("Loading {0}, returning null", ContentHash);
            return default(T);
        }

        public object Load(Guid ContentHash) 
        {
            log.Debug("Loading {0}, returning null", ContentHash);
            return null;
        }

        public void Save<T>(T Obj) where T : ISerializableItem
        {
            log.Debug("Saving {0}", Obj.ContentHash);
        }

        public void FlushChanges()
        {
            log.Debug("Flush");
        }

        public Guid[] GetAllObjectHashes()
        {
            return new Guid[0];
        }

        public int GetObjectCount()
        {
            return 0;
        }

        public ISyncPointInformation CreateSyncPoint<T>(T obj, string qualifier = null, DateTimeOffset? createdOn = null) 
            where T : ISerializableItem
        {
            log.Debug("Creating sync point for {0} ({1})", obj.ContentHash, qualifier);
            return new SyncPointInformation(Guid.Empty, Guid.Empty, typeof (T), qualifier ?? String.Empty, createdOn ?? DateTimeOffset.Now);
        }

        public Guid[] GetOrderedRevisionList(Type type, string qualifier = null) 
        {
            return null;
        }

        public void Dispose()
        {
        }
    }
}

// vim: tw=120 ts=4 sw=4 et :
