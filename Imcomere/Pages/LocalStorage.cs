using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Imcomere.Pages
{
    public class LocalStorage(IJSRuntime jsRuntime)
    {
        public async Task set(string key, string value)
            => await jsRuntime.InvokeVoidAsync("localStorage.setItem", key, value);

        public async Task set<T>(string key, T value) where T : class
            => await set(key, JsonConvert.SerializeObject(value));

        private async Task<string?> get(string key)
        {
            var task = await jsRuntime.InvokeAsync<string>("localStorage.getItem", key);
            return task;
        }

        public async Task<T?> get<T>(string key) where T : class
        {
            var result = await get(key);
            return result == null ? null : JsonConvert.DeserializeObject<T>(result);
        }

        public async Task clear()
            => await jsRuntime.InvokeVoidAsync("localStorage.clear");

        public async Task remove(string key)
            => await jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
    }
}
