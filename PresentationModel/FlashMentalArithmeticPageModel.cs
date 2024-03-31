using CommunityToolkit.Mvvm.Messaging;
using DomainLayer.MentalArithmetic;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace PresentationModel
{
    // All the code in this file is included in all platforms.
    public class FlashMentalArithmeticPageModel
    {
        private readonly CompositeDisposable disposables = new();

        public AsyncReactiveCommand StartFlashMentalArithmeticCommand { get; } = new AsyncReactiveCommand();

        public ReactiveCommand<int> ConfirmCommand { get; } = new ReactiveCommand<int>();

        public ReadOnlyReactiveProperty<int> CurrentValue { get; }

        public ReadOnlyReactiveProperty<int> TotalValue { get; }

        public FlashMentalArithmeticPageModel()
        {
            StartFlashMentalArithmeticCommand.Subscribe(MentalArithmeticService.RaiseRandomValue).AddTo(disposables);
            CurrentValue = MentalArithmeticService.RandomValueObservable.ToReadOnlyReactiveProperty();
            TotalValue = MentalArithmeticService.RandomValueObservable
                .SkipUntil(MentalArithmeticService.RandomValueRaiseStartObservable)
                .TakeUntil(MentalArithmeticService.RandomValueRaiseEndObservable)
                .Sum()
                .Repeat()
                .ToReadOnlyReactiveProperty()
                .AddTo(this.disposables);

            ConfirmCommand.Subscribe(value => StrongReferenceMessenger.Default.Send(new AcceptAnswerMessage(value == TotalValue.Value))).AddTo(disposables);
        }
    }
}
