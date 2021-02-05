using System;
using System.Collections.Generic;

namespace NoRealm.Phi.Shared.Features
{
    /// <summary>
    /// Represent a collection of features
    /// </summary>
    public interface IFeatureCollection : IEnumerable<KeyValuePair<Type, object>>
    {
        /// <summary>
        /// Get saved feature.
        /// </summary>
        /// <typeparam name="TFeature">feature type.</typeparam>
        /// <returns>The requested feature, or null if it is not present.</returns>
        TFeature Get<TFeature>() where TFeature : class;

        /// <summary>
        /// Save a feature. Passing null removes the feature.
        /// </summary>
        /// <typeparam name="TFeature">feature type.</typeparam>
        /// <param name="instance">an instance or null to remove stored feature.</param>
        void Set<TFeature>(TFeature instance) where TFeature : class;

        /// <summary>
        /// Remove feature if already exists.
        /// </summary>
        /// <typeparam name="TFeature">feature type.</typeparam>
        void Remove<TFeature>() where TFeature : class;

        /// <summary>
        /// determine whether certain feature exists.
        /// </summary>
        /// <typeparam name="TFeature">feature type.</typeparam>
        /// <returns>true if feature exists, otherwise false;</returns>
        bool IsExist<TFeature>();

        /// <summary>
        /// Get/set a given feature. Setting a null removes the feature.
        /// </summary>
        /// <param name="type">feature type.</param>
        /// <returns>The requested feature, or null if it is not present.</returns>
        object this[Type type] { get; set; }
    }
}
