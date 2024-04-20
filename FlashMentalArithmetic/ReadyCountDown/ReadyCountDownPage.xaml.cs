using CommunityToolkit.HighPerformance.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using PresentationModel;
using Reactive.Bindings;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;

namespace FlashMentalArithmetic;

public partial class ReadyCountDownPage : ContentPage
{
    public static double Radius { get; } = 25;

    public static Size Size { get; } = new Size(Radius, Radius);

    private static readonly uint millisecondsPerSecond = 1000;

    public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int), typeof(ReadyCountDownPage), default(int));

    public int Count
    {
        get => (int)GetValue(CountProperty);
        private set => SetValue(CountProperty, value);
    }

    public ReadyCountDownPage(int countDownCount = 3)
	{
		InitializeComponent();
        Count = countDownCount;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        PathFigure.StartPoint = new Point(this.Width / 2, this.Height / 2 - Radius);

        var animation = new Animation(v => {
            ArcSegment.Point = new Point(PathFigure.StartPoint.X + Radius * Math.Sin(v * Math.Tau), PathFigure.StartPoint.Y + Radius - Radius * Math.Cos(v * Math.Tau));
            ArcSegment.IsLargeArc = v - Math.Truncate(v) > 0.5;
        },start:0.005, end:0.999);

        this.Animate("trans", animation, length : millisecondsPerSecond, finished: (_1, _2) => {
            if(Count == 0) Navigation.PopModalAsync(false); 
        }, repeat: () => Count-- > 0);
    }
}