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

            var observable = WeakReferenceMessenger.Default.CreateObservable<AcceptAnswerMessage>();
            observable.Where(message => message.Value).Subscribe(async _ => await Toast.Make("正解!").Show());
            observable.Where(message => !message.Value).Subscribe(async _ => await Toast.Make("不正解!").Show());
        }
    }
}
