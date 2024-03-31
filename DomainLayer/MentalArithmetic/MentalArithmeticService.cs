using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;

namespace DomainLayer.MentalArithmetic
{
    // All the code in this file is included in all platforms.
    public static class MentalArithmeticService
    {
        private static readonly Subject<int> randomValuesubject = new Subject<int>();

        private static readonly Subject<Unit> randomValueRaiseStart = new Subject<Unit>();

        private static readonly Subject<Unit> randomValueRaiseEnd = new Subject<Unit>();

        public static IObservable<Unit> RandomValueRaiseStartObservable => randomValueRaiseStart.AsObservable();

        public static IObservable<int> RandomValueObservable => randomValuesubject.AsObservable();

        public static IObservable<Unit> RandomValueRaiseEndObservable => randomValueRaiseEnd.AsObservable();

        public static async Task RaiseRandomValue()
        {
            randomValueRaiseStart.OnNext(Unit.Default);
            randomValuesubject.OnNext(Random.Shared.Next(100));
            await Task.Delay(1000);
            randomValuesubject.OnNext(Random.Shared.Next(100));
            await Task.Delay(1000);
            randomValuesubject.OnNext(Random.Shared.Next(100));
            await Task.Delay(1000);
            randomValuesubject.OnNext(Random.Shared.Next(100));
            await Task.Delay(1000);
            randomValuesubject.OnNext(Random.Shared.Next(100));
            await Task.Delay(1000);
            randomValueRaiseEnd.OnNext(Unit.Default);
        }
    }
}
