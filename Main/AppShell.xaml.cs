
using View2;

namespace Main
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
