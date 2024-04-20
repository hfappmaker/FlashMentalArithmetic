using CommunityToolkit.Mvvm.Messaging;
using DomainLayer.MentalArithmetic;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class FlashMentalArithmeticPageModel
    {
        private readonly CompositeDisposable disposables = new();

        public AsyncReactiveCommand StartFlashMentalArithmeticCommand { get; } = new AsyncReactiveCommand();

        public ReactiveCommand<int> ConfirmCommand { get; } = new ReactiveCommand<int>();

        public ReactiveProperty<string> CurrentValue { get; } = new ReactiveProperty<string>();

        public ReactiveProperty<int> TotalValue { get; } = new ReactiveProperty<int>();

        public FlashMentalArithmeticPageModel()
        {
            StartFlashMentalArithmeticCommand.Subscribe(async _ => {
                var values = MentalArithmeticService.GetRandomValues(5, 10);
                TotalValue.Value = 0;
                foreach (var value in values)
                {
                    CurrentValue.Value = value.ToString();
                    TotalValue.Value += value;
                    await Task.Delay(500);
                    CurrentValue.Value = string.Empty;
                    await Task.Delay(500);
                }
            }).AddTo(disposables);

            ConfirmCommand.Subscribe(value => StrongReferenceMessenger.Default.Send(new ToastMessage(value == TotalValue.Value ? ToastMessageType.Correct : ToastMessageType.Incorrect))).AddTo(disposables);
        }
    }
}
