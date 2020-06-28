using NoRealm.Phi.Shared.Utility;
using Xunit;

namespace NoRealm.Phi.Shared.Test.Utility
{
    /// <summary>
    /// <see cref="ObjectExtensions"/> tests
    /// </summary>
    public class ObjectExtensionsTest
    {
        [Fact]
        public void TypeOfNullStringSuccess()
        {
            Assert.Same(typeof(string), ((string)null).TypeOf());
        }

        [Fact]
        public void TypeOfStringSuccess()
        {
            Assert.Same(typeof(string), "".TypeOf());
        }

        [Fact]
        public void TypeOfNullIntSuccess()
        {
            Assert.Same(typeof(int?), ((int?)null).TypeOf());
        }

        [Fact]
        public void TypeOfIntSuccess()
        {
            Assert.Same(typeof(int), 10.TypeOf());
        }

        [Fact]
        public void TypeOfNullObjectSuccess()
        {
            Assert.Same(typeof(object), ((object)null).TypeOf());
        }
    }
}
