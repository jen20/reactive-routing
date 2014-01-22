using System.Globalization;

namespace ReactiveRouting
{
    /// <summary>
    /// Such thread safety.
    /// </summary>
    public static class ViewInstanceCount
    {
        private static int _instanceCount;

        public static string InstanceCount
        {
            get { return _instanceCount.ToString(CultureInfo.InvariantCulture); }
        }

        public static void Increment()
        {
            _instanceCount++;
        }
    }
}