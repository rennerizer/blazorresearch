namespace LocalStorage.Services
{
    public interface ILocalStorageService
    {
        ValueTask SetItemAsync<T>(string key, T value);

        ValueTask<T?> GetItemAsync<T>(string key);
    }
}
