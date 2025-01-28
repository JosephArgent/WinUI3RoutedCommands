using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace RoutedCommands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "WinUI 3 Routed Commands";
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(null);
        }

        private async void SayHello_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameStr.Text))
            {
                ContentDialog dialog = new ContentDialog
                {
                    XamlRoot = Content.XamlRoot,
                    Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style,
                    Title = "Hello",
                    Content = $"Hello, {NameStr.Text}!",
                    CloseButtonText = "OK"
                };

                await dialog.ShowAsync();
            }
        }
    }

    public static class Command
    {
        public static readonly RoutedUICommand cmdSayHello =
            new RoutedUICommand("Say Hello Menu", "DoSayHello", 
                typeof(MainWindow));
    }
}
