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
        public AsyncReactiveCommand MovePageCommand { get; } = new AsyncReactiveCommand();

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            MovePageCommand.Subscribe(async _ => await Shell.Current.GoToAsync((string)query["NextPage"], false));
        }
    }
}
