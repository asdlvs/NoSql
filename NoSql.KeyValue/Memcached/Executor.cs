namespace NoSql.KeyValue.Memcached
{
    using System;
    using System.Diagnostics;

    using NoSql.Common.Abstract;

    public class Executor : IExecutor
    {
        public TimeSpan Execute()
        {
            var sw = new Stopwatch();
            sw.Start();

            const string Key = "person1";
            var value = new Person
            {
                Name = "Vitaliy Lebedev",
                Mail = "asdfghjklzxc@yandex.ru",
                BirthDate = new DateTime(1988, 12, 18)
            };

            var profile = new ProfileStorage();

            profile.Set(Key, value);
            var result = profile.Get<Person>(Key);

            if (result.Mail != value.Mail) { throw new Exception("Wrong mail"); }
            if (result.Name != value.Name) { throw new Exception("Wrong name"); }
            if (result.BirthDate != value.BirthDate) { throw new Exception("Wrong birthdate"); }

            sw.Stop();
            return sw.Elapsed;
        }

        class Person
        {
            public string Name { get; set; }
            public string Mail { get; set; }
            public DateTime BirthDate { get; set; }
        }
    }
}
