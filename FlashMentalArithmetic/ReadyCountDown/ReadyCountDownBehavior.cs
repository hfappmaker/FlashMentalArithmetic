using Reactive.Bindings.Extensions;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace FlashMentalArithmetic
{
    internal class ReadyCountDownBehavior: Behavior<ContentPage>
    {
        private readonly CompositeDisposable disposables = new();

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            Observable.FromEventPattern(bindable, nameof(bindable.Loaded))
                .Subscribe(async _ => {
                    await bindable.Navigation.PushModalAsync(new ReadyCountDownPage(), false);
                })
                .AddTo(disposables);
        }
        
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            disposables.Clear();
        }
    }
}
