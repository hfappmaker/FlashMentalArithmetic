﻿namespace FlashMentalArithmetic
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ReadyCountDownPage), new ShellNavigationQueryParameters(new Dictionary<string, object>()
            {
                {"NextPage", nameof(FlashMentalArithmeticPage) },
            }));
        }
    }

}
