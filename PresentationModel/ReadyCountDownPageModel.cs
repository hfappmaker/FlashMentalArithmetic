using CommunityToolkit.Mvvm.Messaging;
using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace PresentationModel
{
    public class ReadyCountDownPageModel : IQueryAttributable
    {
        private static readonly int _countDownCount = 3;

        private readonly CompositeDisposable disposables = new CompositeDisposable();

        public ReactiveProperty<int> Count { get; } = new ReactiveProperty<int>(_countDownCount);

        public AsyncReactiveCommand StartCountDownCommand { get; } = new AsyncReactiveCommand();


        private readonly Subject<Unit> countdownEndSubject = new Subject<Unit>();

        public ReadyCountDownPageModel() 
        {
            async Task CountDownStart()
            {
                while(Count.Value > 0)
                {
                    await Task.Delay(1000);
                    Count.Value--;
                }

                countdownEndSubject.OnNext(Unit.Default);
            }

            StartCountDownCommand.Subscribe(CountDownStart).AddTo(this.disposables);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            countdownEndSubject.Subscribe(async _ => await Shell.Current.GoToAsync((string)query["NextPage"], false));
        }
    }
}
