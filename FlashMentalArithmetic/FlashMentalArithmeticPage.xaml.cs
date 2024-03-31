using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using PresentationModel;
using System.Reactive.Linq;

namespace FlashMentalArithmetic;

public partial class FlashMentalArithmeticPage : ContentPage
{
    public FlashMentalArithmeticPage()
	{
		InitializeComponent();

        var observable = StrongReferenceMessenger.Default.CreateObservable<AcceptAnswerMessage>();
        observable.Where(message => message.Value).Subscribe(async _ => await Toast.Make("ê≥â!").Show());
        observable.Where(message => !message.Value).Subscribe(async _ => await Toast.Make("ïsê≥â!").Show());
    }
}