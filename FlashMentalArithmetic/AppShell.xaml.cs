namespace FlashMentalArithmetic
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(FlashMentalArithmeticPage), typeof(FlashMentalArithmeticPage));
            Routing.RegisterRoute(nameof(ReadyCountDownPage), typeof(ReadyCountDownPage));
        }
    }
}
