namespace GreenChatMobileMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Removed MainPage assignment to resolve CS0618 and CA1416 diagnostics.
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Correctly initialize the root page using CreateWindow method.
            return new Window(new AppShell());
        }
    }
}