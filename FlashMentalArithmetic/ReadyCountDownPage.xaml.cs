using CommunityToolkit.HighPerformance.Helpers;
using PresentationModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;

namespace FlashMentalArithmetic;

public partial class ReadyCountDownPage : ContentPage
{
    public ReadyCountDownPage()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {

        var animation = new Animation(v => { 
            ArcSegment.SetValue(Microsoft.Maui.Controls.Shapes.ArcSegment.RotationAngleProperty, v);
        }, 0, 360 * 3, Easing.Linear, () => (this.BindingContext as ReadyCountDownPageModel)?.MovePageCommand.Execute());
        this.Animate("trans", animation, 16, 3000);
    }
}