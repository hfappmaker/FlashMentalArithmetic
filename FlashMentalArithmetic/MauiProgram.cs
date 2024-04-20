using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using PresentationModel;
using CommunityToolkit.Maui.Alerts;
using System.Reactive.Linq;
using Reactive.Bindings.Extensions;

namespace FlashMentalArithmetic
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var toastMessageDictionary = typeof(Resources.Strings.Resource).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetProperty)
                .Select(propertyInfo => propertyInfo.GetMethod)
                .Where(methodInfo => methodInfo != null && methodInfo.ReturnType == typeof(string))
                .ToDictionary(methodInfo => methodInfo.Name.Substring(4), methodInfo => methodInfo.CreateDelegate<Func<string>>()());

            var observable = StrongReferenceMessenger.Default.CreateObservable<ToastMessage>();
            observable.Subscribe(async toastMessage => await Toast.Make(toastMessageDictionary[toastMessage.Value.ToString()]).Show());

            return builder.Build();
        }
    }
}