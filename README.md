# GreenChatMobileMaui

GreenChatMobileMaui is a cross-platform mobile chat application built with .NET MAUI. It provides real-time messaging, user authentication, and discussion threads, making it a modern and extensible chat solution for mobile devices.

---

## Features

- **Real-time Chat:** Send and receive messages instantly (SignalR-powered).
- **User Authentication:** Register and log in securely.
- **Discussion Threads:** Create and view discussion threads.
- **Cross-Platform:** Runs on Android, iOS, and other platforms supported by .NET MAUI.
- **Modern UI:** Built with XAML and .NET MAUI for a native look and feel.

![GreenChatMobileMaui](https://github.com/user-attachments/assets/2611ff56-5236-4fb4-a102-07663ee40ebe)

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) with MAUI workload

## API Service Overview

The `ApiService` class provides methods for interacting with the backend:

### Authentication
- **Register**
await apiService.RegisterAsync("username", "email@example.com", "password");
- **Login**
await apiService.LoginAsync("username", "password");

### Chat
- **Start Chat Connection**
await apiService.StartChatAsync();
- **Send Message**
await apiService.SendMessageAsync("YourUserName", "Hello, world!");
- **Get Test Chat Message**
string testMessage = await apiService.GetChatTestAsync();

### Threads
- **Get Threads**
List<DiscussionThread> threads = await apiService.GetThreadsAsync();
- **Create Thread**
var thread = new DiscussionThread { Title = "New Topic", Content = "Let's discuss .NET MAUI!" };
await apiService.CreateThreadAsync(thread);

---

## API Endpoints

> _These are example endpoints. Update with your actual backend URLs and request/response formats._

- `POST /api/auth/register` – Register a new user
- `POST /api/auth/login` – Authenticate a user
- `GET /api/threads` – Get all discussion threads
- `POST /api/threads` – Create a new thread
- `POST /api/chat/send` – Send a chat message (SignalR endpoint)

---

## Project Structure

- `ChatPage.xaml` / `ChatPage.xaml.cs`: Main chat UI and logic.
- `Services/ApiService.cs`: Handles API calls, authentication, and SignalR communication.
- `Models/DiscussionThread.cs`: Represents discussion threads.

---

## Technologies Used

- [.NET MAUI](https://github.com/dotnet/maui)
- [SignalR](https://docs.microsoft.com/aspnet/core/signalr/introduction)
- [System.Net.Http](https://docs.microsoft.com/dotnet/api/system.net.http)


