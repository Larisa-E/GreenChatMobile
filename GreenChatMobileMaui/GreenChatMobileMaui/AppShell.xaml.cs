namespace GreenChatMobileMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Discussions", typeof(DiscussionsPage));
        }
    }
}
