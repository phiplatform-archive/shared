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
            var col = new FeatureCollection(false);

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
            var col = new FeatureCollection(false);

            col.Set("non-value");
            col.Set(Value.None);

            Assert.Same(Value.None, col.Get<Value>());
        }

        [Fact]
        public void DisposeOnNullWillNotInvokeSuccess()
        {
            var col = new FeatureCollection(false);
            var d = new DisposableClass();

            Assert.False(d.IsDisposed);

            col.Set(d);
            col.Set<DisposableClass>(null);

            Assert.False(d.IsDisposed);
        }

        [Fact]
        public void DisposeOnNullInvokedSuccess()
        {
            var col = new FeatureCollection(true);
            var d = new DisposableClass();

            Assert.False(d.IsDisposed);

            col.Set(d);
            col.Set<DisposableClass>(null);

            Assert.True(d.IsDisposed);
        }

        [Fact]
        public void DisposeOnSameObjectWillNotInvokedSuccess()
        {
            var col = new FeatureCollection(true);
            var d = new DisposableClass();

            Assert.False(d.IsDisposed);

            col.Set(d);
            col.Set(d);

            Assert.False(d.IsDisposed);
        }

        [Fact]
        public void DisposeOnDiffObjectsWillInvokedSuccess()
        {
            var col = new FeatureCollection(true);
            var d = new DisposableClass();

            Assert.False(d.IsDisposed);

            col.Set(d);
            col.Set(new DisposableClass());

            Assert.True(d.IsDisposed);
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
