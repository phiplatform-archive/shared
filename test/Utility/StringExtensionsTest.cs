using NoRealm.Phi.Shared.Utility;
using Xunit;

namespace NoRealm.Phi.Shared.Test.Utility
{
    /// <summary>
    /// <see cref="StringExtensions"/> tests
    /// </summary>
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData(null, 0x0ul)]
        [InlineData("", 0xcbf29ce484222325ul)]
        [InlineData(nameof(StringExtensions), 0x44b3c8aebb0c77a8ul)]
        public void ComputeFnv1Success(string value, ulong expectedValue)
            => Assert.Equal(expectedValue, value.ComputeFnv1());
    }
}
