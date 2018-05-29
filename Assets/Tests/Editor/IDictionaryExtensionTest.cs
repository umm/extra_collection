using System.Collections.Generic;
using NUnit.Framework;

namespace ExtraCollection
{
    public class IDictionaryExtensionTest
    {
        [Test]
        public void GetOrDefaultTest()
        {
            var dictionary = new Dictionary<int, string>();
            Assert.IsNull(dictionary.GetOrDefault(0));

            dictionary[0] = "mario";
            Assert.AreEqual("mario", dictionary.GetOrDefault(0));
        }

        [Test]
        public void GetOrSetTest()
        {
            var dictionary = new Dictionary<int, string>();
            Assert.AreEqual("wario", dictionary.GetOrSet(0, () => "wario"));

            dictionary[0] = "mario";
            Assert.AreEqual("mario", dictionary.GetOrSet(0, () => "wario"));
        }

        [Test]
        public void AddOrSetTest()
        {
            {
                var dictionary = new Dictionary<int, int>();
                dictionary.AddOrSet(0, -1);
                Assert.AreEqual(-1, dictionary[0]);
                dictionary.AddOrSet(0, 2);
                Assert.AreEqual(1, dictionary[0]);
            }

            {
                var dictionary = new Dictionary<int, float>();
                dictionary.AddOrSet(0, -1f);
                Assert.AreEqual(-1f, dictionary[0], 0.00001f);
                dictionary.AddOrSet(0, 2f);
                Assert.AreEqual(1f, dictionary[0], 0.00001f);
            }
        }
    }
}