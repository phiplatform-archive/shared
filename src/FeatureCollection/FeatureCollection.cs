using System;
using System.Collections;
using System.Collections.Generic;

namespace NoRealm.Phi.Shared.Features
{
    /// <summary>
    /// A feature collection
    /// </summary>
    public class FeatureCollection : IFeatureCollection
    {
        private readonly IDictionary<Type, object> resources = new Dictionary<Type, object>();

        /// <summary>
        /// initialize new instance
        /// </summary>
        /// <param name="disposeOnRemove">set to true to call <see cref="IDisposable.Dispose"/> upon removing feature from collection</param>
        public FeatureCollection(bool disposeOnRemove)
            => DisposeOnRemove = disposeOnRemove;

        /// <inheritdoc />
        public bool DisposeOnRemove { get; }

        /// <inheritdoc />
        public TFeature Get<TFeature>() where TFeature : class
            => (TFeature) this[typeof(TFeature)];

        /// <inheritdoc />
        public void Set<TFeature>(TFeature instance) where TFeature : class
            => this[typeof(TFeature)] = instance;

        /// <inheritdoc />
        public bool IsExist<TFeature>()
            => resources.ContainsKey(typeof(TFeature));

        /// <inheritdoc />
        public object this[Type type]
        {
            get => resources.TryGetValue(type, out var instance) ? instance : null;

            set
            {
                if (resources.ContainsKey(type))
                {
                    var old = resources[type];

                    if (value == null)
                        resources.Remove(type);
                    else
                        resources[type] = value;

                    if (!DisposeOnRemove) return;

                    if (old != value && old is IDisposable dispose)
                        dispose.Dispose();
                }
                else if (value != null)
                    resources.Add(type, value);
            }
        }

        /// <summary>
        /// get enumerator
        /// </summary>
        /// <returns>enumerator object</returns>
        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator() => resources.GetEnumerator();

        /// <summary>
        /// get enumerator
        /// </summary>
        /// <returns>enumerator object</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
