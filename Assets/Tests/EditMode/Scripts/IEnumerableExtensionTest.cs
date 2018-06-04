using System.Collections.Generic;
using NUnit.Framework;

namespace ExtraCollection
{
    public class IEnumerableExtensionTest
    {
        [Test]
        public void FindMaxOrDefault()
        {
            Assert.AreEqual("three", new[]
            {
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(3, "three"),
            }.FindMaxOrDefault(it => it.Key).Value);

            Assert.AreEqual("three1", new[]
            {
                new KeyValuePair<int, string>(1, "one"),
                new KeyValuePair<int, string>(2, "two"),
                new KeyValuePair<int, string>(3, "three1"),
                new KeyValuePair<int, string>(3, "three2"),
            }.FindMaxOrDefault(it => it.Key).Value);

            Assert.AreEqual(
                "one",
                new[] {new KeyValuePair<int, string>(1, "one")}
                    .FindMaxOrDefault(it => it.Key).Value
            );

            Assert.AreEqual(
                new KeyValuePair<int, string>(0, null),
                new KeyValuePair<int, string>[] { }.FindMaxOrDefault(it => it.Key)
            );
        }

        [Test]
        public void ScanTest()
        {
            // normal
            {
                var original = new[] {1, 2, 3};
                var expected = new[] {1, 3, 6};

                Assert.AreEqual(original.Scan((sum, it) => sum + it), expected);
            }

            // single element
            {
                var original = new[] {1};
                var expected = new[] {1};

                Assert.AreEqual(original.Scan((sum, it) => sum + it), expected);
            }

            // empty
            {
                var original = new int[] { };
                var expected = new int[] { };

                Assert.AreEqual(original.Scan((sum, it) => sum + it), expected);
            }
        }

        [Test]
        public void StringJoinTest()
        {
            Assert.AreEqual("a,b,c", new []{"a","b","c"}.StringJoin(","));
            Assert.AreEqual("a", new []{"a"}.StringJoin(","));
            Assert.AreEqual("", new string[0].StringJoin(","));
        }
    }
}