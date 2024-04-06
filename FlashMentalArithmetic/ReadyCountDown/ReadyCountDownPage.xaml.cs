using CommunityToolkit.HighPerformance.Helpers;
using PresentationModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;

namespace FlashMentalArithmetic;

public partial class ReadyCountDownPage : ContentPage
{
    private readonly int _countDownCount;
    private static readonly int millisecondsPerSecond = 1000;
    public ReadyCountDownPage(int countDownCount = 3)
	{
		InitializeComponent();
        _countDownCount = countDownCount;

    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        await Task.Delay(_countDownCount * millisecondsPerSecond);
        await Navigation.PopModalAsync(false);
    }
}