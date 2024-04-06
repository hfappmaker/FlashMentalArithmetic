using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;

namespace DomainLayer.MentalArithmetic
{
    public static class MentalArithmeticService
    {
        public static IEnumerable<int> GetRandomValues(int count, int maxValue)
        {
            foreach (var _ in Enumerable.Range(0, count))
            {
                yield return Random.Shared.Next(maxValue+1);
            }
        }
    }
}
