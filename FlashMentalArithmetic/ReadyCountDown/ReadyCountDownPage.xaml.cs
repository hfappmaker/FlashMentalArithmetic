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

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        var animation = new Animation(v => {
            ArcSegment.Point = new Point(85 * v, 110 * v);
        }, 0, 3, Easing.Linear, () => { });
        this.Animate("trans", animation, 16, 3000, Easing.Linear, async (v, _) => await Navigation.PopModalAsync(false), () => false);
    }
}