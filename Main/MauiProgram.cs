using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Logging;
using CommonPresentationModel;
using Main.Resources.Strings;

namespace Main
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

            var toastMessageDictionary = typeof(ToastMessageString).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetProperty)
                .Select(propertyInfo => propertyInfo.GetMethod)
                .Where(methodInfo => methodInfo != null && methodInfo.ReturnType == typeof(string))
                .ToDictionary(methodInfo => methodInfo.Name[4..], methodInfo => methodInfo.CreateDelegate<Func<string>>()());

            var observable = StrongReferenceMessenger.Default.CreateObservable<ToastMessage>();
            observable.Subscribe(async toastMessage => await Toast.Make(toastMessageDictionary[toastMessage.Value.ToString()]).Show());


            return builder.Build();
        }
    }
}
