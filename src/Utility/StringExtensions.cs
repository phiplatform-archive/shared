namespace NoRealm.Phi.Shared.Utility
{
    /// <summary>
    /// extension methods to support <see cref="string"/> type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// compute FNV1 hash code
        /// </summary>
        /// <param name="value">string to compute hash code</param>
        /// <returns>FNV1 hash code; zero for null string; fixed value for empty string</returns>
        public static ulong ComputeFnv1(this string value)
        {
            if (value == null) return 0;

            var hash = 14695981039346656037ul;

            if (string.IsNullOrEmpty(value)) return hash;

            for (var i = 0; i < value.Length; ++i) {
                hash *= 1099511628211ul;
                hash ^= value[i];
            }

            return hash;
        }

        /// <summary>
        /// compute Murmur hash code
        /// </summary>
        /// <param name="value">string to compute hash code</param>
        /// <returns>Murmur hash code; zero for null string; fixed value for empty string</returns>
        public static ulong ComputeMurmur(this string value)
        {
            if (value == null) return 0;

            var hash = 525201411107845655ul;

            if (string.IsNullOrEmpty(value)) return hash;

            for (var i=0; i<value.Length;++i)
            {
                hash ^= value[i];
                hash *= 0x5bd1e9955bd1e995;
                hash ^= hash >> 47;
            }
            return hash;
        }
    }
}
