using CommunityToolkit.Maui;

namespace View2
{
    public partial class FlashMentalArithmeticPage : ContentPage
    {
        public FlashMentalArithmeticPage()
        {
            InitializeComponent();
        }

        private void Fake()
        {
            // UseMauiCommunityToolkitを呼び出さないと、xamlでxmlns:toolkitを利用出来ないらしい
            // その為、どこからも呼び出さないFakeメソッドを定義しておく
            // https://stackoverflow.com/questions/76452760/net-maui-library-xamlc-error-xfc0000-cannot-resolve-type
            _ = MauiApp.CreateBuilder().UseMauiCommunityToolkit();
        }
    }
}
