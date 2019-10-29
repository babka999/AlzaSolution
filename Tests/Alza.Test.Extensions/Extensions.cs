using NUnit.Framework;

namespace Alza.Test.Extensions
{
    public static class Extensions
    {
        public static T ShouldEqual<T>(this T actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return actual;
        }
    }
}