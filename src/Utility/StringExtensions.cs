namespace NoRealm.Phi.Shared.Utility
{
    /// <summary>
    /// extension methods to support <see cref="string"/> type
    /// </summary>
    public static class StringExtensions
    {
        private const ulong FnvPrime = 1099511628211ul;
        private const ulong FnvOffsetBasis = 14695981039346656037ul;

        /// <summary>
        /// compute FNV1 hash code
        /// </summary>
        /// <param name="value">string to compute hash code</param>
        /// <returns>FNV1 hash code; zero for empty or null string</returns>
        public static ulong ComputeFnv1(this string value)
        {
			if (value == null) return 0;
            if (string.IsNullOrEmpty(value)) return FnvOffsetBasis;

            var hash = FnvOffsetBasis;

            for (var i = 0; i < value.Length; ++i) {
                hash *= FnvPrime;
                hash ^= value[i];
            }

            return hash;
        }
    }
}
