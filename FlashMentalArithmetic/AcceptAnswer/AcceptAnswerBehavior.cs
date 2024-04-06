using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Messaging;
using PresentationModel;
using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace FlashMentalArithmetic
{
    internal class AcceptAnswerBehavior : Behavior<ContentPage>
    {
        private readonly CompositeDisposable disposables = new();

        private static readonly IReadOnlyDictionary<string, string> toastMessageDictionary;

        static AcceptAnswerBehavior()
        {
            toastMessageDictionary = typeof(Resources.Strings.Resource).GetProperties(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetProperty)
                .Select(propertyInfo => propertyInfo.GetMethod)
                .Where(methodInfo => methodInfo != null && methodInfo.ReturnType == typeof(string))
                .ToDictionary(methodInfo => methodInfo.Name.Substring(4), methodInfo => methodInfo.CreateDelegate<Func<string>>()());
        }

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            var observable = StrongReferenceMessenger.Default.CreateObservable<ToastMessage>();
            observable.Subscribe(async toastMessage => await Toast.Make(toastMessageDictionary[toastMessage.Value.ToString()]).Show()).AddTo(this.disposables);
        }
        
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            disposables.Clear();
        }
    }
}
