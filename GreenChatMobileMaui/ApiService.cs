using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://172.16.30.26:5000/api/") 
        };
    }

    // Threads
    public async Task<List<DiscussionThread>> GetThreadsAsync()
        => await _httpClient.GetFromJsonAsync<List<DiscussionThread>>("threadsapi");

    public async Task<bool> CreateThreadAsync(DiscussionThread thread)
        => (await _httpClient.PostAsJsonAsync("threadsapi", thread)).IsSuccessStatusCode;

    // Auth
    public async Task<bool> RegisterAsync(string username, string email, string password)
    {
        var model = new { Username = username, Email = email, Password = password };
        var response = await _httpClient.PostAsJsonAsync("authapi/register", model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var model = new { Username = username, Password = password };
        var response = await _httpClient.PostAsJsonAsync("authapi/login", model);
        return response.IsSuccessStatusCode;
    }

    // Chat test (not real-time)
    public async Task<string> GetChatTestAsync()
    {
        var response = await _httpClient.GetAsync("chatapi/chat");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}