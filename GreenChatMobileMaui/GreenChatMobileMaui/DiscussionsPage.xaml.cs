using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenChatMobileMaui.Services;

namespace GreenChatMobileMaui
{
    public partial class DiscussionsPage : ContentPage
    {
        private readonly ApiService _apiService;

        public DiscussionsPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
            LoadThreads();
        }

        private async void LoadThreads()
        {
            var threads = await _apiService.GetThreadsAsync();
            // TODO: Bind 'threads' to your UI, e.g., a CollectionView's ItemsSource
        }
    }
}
