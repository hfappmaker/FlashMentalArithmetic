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
            // UseMauiCommunityToolkit���Ăяo���Ȃ��ƁAxaml��xmlns:toolkit�𗘗p�o���Ȃ��炵��
            // ���ׁ̈A�ǂ�������Ăяo���Ȃ�Fake���\�b�h���`���Ă���
            // https://stackoverflow.com/questions/76452760/net-maui-library-xamlc-error-xfc0000-cannot-resolve-type
            _ = MauiApp.CreateBuilder().UseMauiCommunityToolkit();
        }
    }
}
