using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NoRealm.Phi.Shared.Features
{
    /// <summary>
    /// A feature collection
    /// </summary>
    public class FeatureCollection : IFeatureCollection
    {
        private readonly IDictionary<Type, object> features = new ConcurrentDictionary<Type, object>();

        /// <inheritdoc />
        public TFeature Get<TFeature>() where TFeature : class
            => (TFeature) this[typeof(TFeature)];

        /// <inheritdoc />
        public void Set<TFeature>(TFeature instance) where TFeature : class
            => this[typeof(TFeature)] = instance;

        /// <inheritdoc />
        public void Remove<TFeature>() where TFeature : class
            => this[typeof(TFeature)] = null;

        /// <inheritdoc />
        public bool IsExist<TFeature>()
            => features.ContainsKey(typeof(TFeature));

        /// <inheritdoc />
        public object this[Type type]
        {
            get => features.TryGetValue(type, out var instance) ? instance : null;

            set
            {
                if (value == null)
                {
                    if (features.ContainsKey(type))
                        features.Remove(type);
                    return;
                }

                if (features.ContainsKey(type))
                    features[type] = value;
                else
                    features.TryAdd(type, value);
            }
        }

        /// <summary>
        /// get enumerator
        /// </summary>
        /// <returns>enumerator object</returns>
        public IEnumerator<KeyValuePair<Type, object>> GetEnumerator() => features.GetEnumerator();

        /// <summary>
        /// get enumerator
        /// </summary>
        /// <returns>enumerator object</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
