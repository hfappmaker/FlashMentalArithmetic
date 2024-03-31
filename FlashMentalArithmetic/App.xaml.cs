using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using PresentationModel;
using System.Reactive.Linq;

namespace FlashMentalArithmetic
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
