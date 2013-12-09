namespace NoSql.KeyValue.Redis
{
    using System;

    using NoSql.Common.Abstract;

    using ServiceStack.Redis;

    public class ProfileStorage : IProfileStorage
    {
        private readonly IRedisClient client;

        protected ProfileStorage(IRedisClient client)
        {
            if (client == null) { throw new ArgumentNullException("client"); }

            this.client = client;
        }

        public ProfileStorage()
            : this(new BasicRedisClientManager("168.63.126.134").GetClient())
        {}

        public T Get<T>(String key)
        {
            return client.Get<T>(key);
        }

        public void Set(String key, Object value)
        {
            client.Set(key, value);
        }
    }
}
