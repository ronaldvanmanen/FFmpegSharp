// This file is part of FFmpegSharp.
//
// FFmpegSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// FFmpegSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with FFmpegSharp.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Linq;
using Xunit;

namespace FFmpegSharp.UnitTests
{
    public static class AVDictionaryTests
    {
        [Fact]
        public static void ContainsKeyReturnsFalseWhenEmpty()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.False(dictionary.ContainsKey("foo"));
            }
        }

        [Fact]
        public static void ContainsKeyReturnsFalseWhenKeyDoesNotExist()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.False(dictionary.ContainsKey("bar"));
                dictionary.Add("foo", "bar");
                Assert.False(dictionary.ContainsKey("bar"));
            }
        }

        [Fact]
        public static void ContainsKeyReturnsTrueAndValueWhenKeyExists()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.False(dictionary.ContainsKey("foo"));
                dictionary.Add("foo", "bar");
                Assert.True(dictionary.ContainsKey("foo"));
            }
        }

        [Fact]
        public static void TryGetValueReturnsFalseWhenEmpty()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.False(dictionary.TryGetValue("foo", out _));
            }
        }

        [Fact]
        public static void TryGetValueReturnsFalseWhenKeyDoesNotExist()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.False(dictionary.TryGetValue("bar", out _));
                dictionary.Add("foo", "bar");
                Assert.False(dictionary.TryGetValue("bar", out _));
            }
        }

        [Fact]
        public static void TryGetValueReturnsTrueWhenKeyExists()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.False(dictionary.TryGetValue("foo", out _));
                dictionary.Add("foo", "bar");
                Assert.True(dictionary.TryGetValue("foo", out var value));
                Assert.Equal("bar", value);
            }
        }

        [Fact]
        public static void CountReturnsZeroWhenEmpty()
        {
            using (var dictionary = new AVDictionary())
            {
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
                Assert.Equal(0, dictionary.Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
            }
        }

        [Fact]
        public static void Empty()
        {
            using (var dictionary = new AVDictionary())
            {
                Assert.Empty(dictionary);
            }
        }

        [Fact]
        public static void AddNewItem()
        {
            using (var dictionary = new AVDictionary())
            {
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
                Assert.Equal(0, dictionary.Count);
                dictionary.Add("foo", "bar");
                Assert.Equal(1, dictionary.Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
            }
        }

        [Fact]
        public static void AddDuplicateItem()
        {
            using (var dictionary = new AVDictionary())
            {
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
                Assert.Equal(0, dictionary.Count);
                dictionary.Add("foo", "bar");
                Assert.Equal(1, dictionary.Count);
                Assert.Throws<ArgumentException>(() => dictionary.Add("foo", "bar"));
                Assert.Equal(1, dictionary.Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
            }
        }

        [Fact]
        public static void Remove()
        {
            using (var dictionary = new AVDictionary())
            {
#pragma warning disable xUnit2013 // Do not use equality check to check for collection size.
                Assert.Equal(0, dictionary.Count);
                dictionary.Add("foo", "bar");
                Assert.Equal(1, dictionary.Count);
                dictionary.Remove("foo");
                Assert.Equal(0, dictionary.Count);
#pragma warning restore xUnit2013 // Do not use equality check to check for collection size.
            }
        }

        [Fact]
        public static void GetEnumerator()
        {
            using var dictionary = new AVDictionary();
            dictionary.Add("foo", "bar");
            var enumerator = dictionary.GetEnumerator();
            Assert.True(enumerator.MoveNext());
            Assert.Equal("foo", enumerator.Current.Key);
            Assert.Equal("bar", enumerator.Current.Value);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public static void Keys()
        {
            using (var dictionary = new AVDictionary())
            {
                dictionary.Add("foo", "bar");
                Assert.Equal(1, dictionary.Keys.Count);
                Assert.Equal("foo", dictionary.Keys.First());
            }
        }

        [Fact]
        public static void Values()
        {
            using (var dictionary = new AVDictionary())
            {
                dictionary.Add("foo", "bar");
                Assert.Equal(1, dictionary.Values.Count);
                Assert.Equal("bar", dictionary.Values.First());
            }
        }
    }
}
