using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NoSql.Common.Abstract;

namespace NoSql.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var noSqls = new Dictionary<string, IExecutor>
           {
               { "riak", new KeyValue.Riak.Executor() },
               { "redis", new KeyValue.Redis.Executor() },
               { "memcached", new KeyValue.Memcached.Executor() }
           };

            var result = noSqls.ToDictionary(pair => pair.Key, pair => pair.Value.Execute());
            foreach (var timeSpan in result)
            {
                Console.WriteLine("{0}: {1}", timeSpan.Key, timeSpan.Value);
            }
            Console.ReadKey();
        }
    }
}
