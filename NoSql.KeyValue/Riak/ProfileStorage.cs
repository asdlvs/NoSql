
namespace NoSql.KeyValue.Riak
{
    using System;

    using CorrugatedIron;
    using CorrugatedIron.Exceptions;
    using CorrugatedIron.Models;
    using NoSql.Common.Abstract;

    public class ProfileStorage : IProfileStorage
    {
        private const string Bucket = "profile";

        private readonly IRiakClient client;

        protected ProfileStorage(IRiakClient client)
        {
            if (client == null) { throw new ArgumentNullException("client"); }

            this.client = client;
        }

        public ProfileStorage()
            : this(RiakCluster.FromConfig("riakConfig").CreateClient())
        {
        }

        public T Get<T>(string key)
        {
            var result = this.client.Get(Bucket, key);

            if (!result.IsSuccess) { throw new FormatException(); }

            return result.Value.GetObject<T>();
        }

        public void Set(string key, object value)
        {
            var result = this.client.Put(new RiakObject(Bucket, key, value));
            if (!result.IsSuccess) { throw new RiakInvalidDataException((byte)result.ResultCode); }
        }
    }
}
