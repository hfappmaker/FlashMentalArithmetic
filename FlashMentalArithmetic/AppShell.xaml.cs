using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using PresentationModel;
using System.Reactive.Linq;

namespace FlashMentalArithmetic
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(FlashMentalArithmeticPage), typeof(FlashMentalArithmeticPage));
        }
    }
}
