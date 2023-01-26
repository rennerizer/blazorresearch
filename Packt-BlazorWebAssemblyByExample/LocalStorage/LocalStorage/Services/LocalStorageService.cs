using System.Text.Json;

using Microsoft.JSInterop;

namespace LocalStorage.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private IJSRuntime _js;

        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _js = jSRuntime;
        }

        public async ValueTask<T?> GetItemAsync<T>(string key)
        {
            var json = await _js.InvokeAsync<string>("interop.getLocalStorage", key);

            return JsonSerializer.Deserialize<T>(json);
        }

        public async ValueTask SetItemAsync<T>(string key, T item)
        {
            await _js.InvokeVoidAsync("interop.setLocalStorage", key, JsonSerializer.Serialize(item));
        }
    }
}
