namespace Interactor
{
    public static class MentalArithmeticService
    {
        public static IEnumerable<int> GetRandomValues(int count, int maxValue)
        {
            foreach (var _ in Enumerable.Range(0, count))
            {
                yield return Random.Shared.Next(maxValue + 1);
            }
        }
    }
}
