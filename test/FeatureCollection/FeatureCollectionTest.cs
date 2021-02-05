using System;
using System.Linq;
using NoRealm.Phi.Shared.Features;
using Xunit;

namespace NoRealm.Phi.Shared.Test.Features
{
    public class FeatureCollectionTest
    {
        [Fact]
        public void FeatureCountSuccess()
        {
            var col = new FeatureCollection();

            col.Set("string data");
            col.Set((object)null);
            col.Set(Value.None);
            Assert.Equal(2, col.Count());

            col.Set((string)null);
            Assert.Single(col);
        }

        [Fact]
        public void GetFeatureSuccess()
        {
            var col = new FeatureCollection();

            col.Set("non-value");
            col.Set(Value.None);

            Assert.Same(Value.None, col.Get<Value>());
        }

        [Fact]
        public void RemoveWillNotDisposeSuccess()
        {
            var col = new FeatureCollection();
            var d = new DisposableClass();

            Assert.False(d.IsDisposed);

            col.Set(d);
            col.Set<DisposableClass>(null);

            Assert.False(d.IsDisposed);
        }

        [Fact]
        public void RemoveFeatureSuccess()
        {
            var col = new FeatureCollection();

            col.Set(Value.None);
            col.IsExist<Value>();

            col.Set<Value>(null);

            Assert.False(col.IsExist<Value>());
        }
    }

    public class DisposableClass : IDisposable
    {
        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}
