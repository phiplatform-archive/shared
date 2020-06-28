using NoRealm.Phi.Shared.Utility;
using Xunit;

namespace NoRealm.Phi.Shared.Test.Utility
{
    /// <summary>
    /// <see cref="ValueExtensions"/> tests
    /// </summary>
    public class ValueExtensionsTest
    {
        [Fact]
        public void IsValueSuccess()
            => Assert.True(Value.None.IsValue());

        [Fact]
        public void IsValueFail()
            => Assert.False("".IsValue());

        [Fact]
        public void IsNoneSuccess()
            => Assert.True(Value.None.IsNone());

        [Fact]
        public void IsNoneFail()
            => Assert.False("".IsNone());
    }
}
