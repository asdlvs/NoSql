namespace NoSql.Common.Abstract
{
    public interface IProfileStorage
    {
        T Get<T>(string key);

        void Set(string key, object value);
    }
}
