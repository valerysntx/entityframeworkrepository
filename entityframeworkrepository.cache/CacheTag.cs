using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace entityframeworkrepository.cache
{
    /// <summary>
    ///  CacheTag
    /// </summary>
    public class CacheTag : ICacheTag
    {
        private readonly string _tag;

        public virtual string Tag
        {
            get { return _tag; }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="CacheTag"/> class.
        /// </summary>
        /// <param name="tag">The tag name.</param>
        public CacheTag(string tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            _tag = tag;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        bool Equals(ICacheTag other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return string.Equals(other.Tag, Tag, StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(CacheTag))
                return false;

            return Equals((CacheTag)obj);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(CacheTag left, CacheTag right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(CacheTag left, CacheTag right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return (Tag != null ? Tag.GetHashCode() : 0);
        }

        public bool Equals(CacheTag other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Tag;
        }

        bool IEquatable<ICacheTag>.Equals(ICacheTag other)
        {
            return Equals((CacheTag) other);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CacheTag"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="cacheTag">The cache tag.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string(CacheTag cacheTag)
        {
            return cacheTag.ToString();
        }
    }
}
