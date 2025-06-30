using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;

namespace GreenChatMobileMaui.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private HubConnection? _hubConnection;

        public event Action<string, string>? OnMessageReceived;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://172.16.30.26:5000/api/")
            };
        }

        // SignalR: Start connection
        public async Task StartChatAsync()
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
                return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://172.16.30.26:5000/chathub")
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                OnMessageReceived?.Invoke(user, message);
            });

            await _hubConnection.StartAsync();
        }

        // SignalR: Send message
        public async Task SendMessageAsync(string user, string message)
        {
            if (_hubConnection != null && _hubConnection.State == HubConnectionState.Connected)
                await _hubConnection.InvokeAsync("SendMessage", user, message);
        }

        // Threads
        public async Task<List<DiscussionThread>> GetThreadsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("threadsapi");
                if (response.IsSuccessStatusCode)
                {
                    var threads = await response.Content.ReadFromJsonAsync<List<DiscussionThread>>();
                    return threads ?? new List<DiscussionThread>();
                }
                else
                {
                    // Optionally log the status code or response for debugging
                    return new List<DiscussionThread>();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching threads: {ex.Message}");
                return new List<DiscussionThread>();
            }
        }

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
}