using GreenChatMobileMaui.Services;

public class ThreadsViewModel
{
    private readonly ApiService _apiService;

    public ThreadsViewModel(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task LoadThreadsAsync()
    {
        var threads = await _apiService.GetThreadsAsync();
        // Use threads in your UI
    }
}