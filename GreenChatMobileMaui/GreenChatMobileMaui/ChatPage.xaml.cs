using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Versioning;
using GreenChatMobileMaui.Services;
using Microsoft.Maui.Controls;

namespace GreenChatMobileMaui
{
    public partial class ChatPage : ContentPage
    {
        private readonly ApiService _apiService;

        public ChatPage(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        public ChatPage() : this(new ApiService()) // Default constructor now initializes _apiService
        {
        }

        private Entry GetMessageEntry()
        {
            return MessageEntry;
        }

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            string message = MessageEntry.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                MessagesListView.ItemsSource = new[] { message }; 
                await _apiService.SendMessageAsync("YourUserName", message);
                MessageEntry.Text = string.Empty; // Clear the entry
            }
        }

        private void ClearMessageEntry()
        {
            MessageEntry.Text = string.Empty;
        }
    }
}
