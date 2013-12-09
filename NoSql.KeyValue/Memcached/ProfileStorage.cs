namespace NoSql.KeyValue.Memcached
{
    using System;
    using System.Collections.Generic;

    using NoSql.Common.Abstract;

    using ServiceStack.Caching;
    using ServiceStack.Caching.Memcached;

    public class ProfileStorage : IProfileStorage
    {
        private readonly IMemcachedClient client;

        protected ProfileStorage(IMemcachedClient client)
        {
            if (client == null) { throw new ArgumentNullException("client"); }

            this.client = client;
        }

        public ProfileStorage()
            : this(new MemcachedClientCache(new List<string> { "168.63.126.134" }))
        {}

        public T Get<T>(String key)
        {
            object o = this.client.Get(key);
            return (T)o;
        }

        public void Set(String key, Object value)
        {
            this.client.Set(key, value);
        }
    }
}
