using NUnit.Framework;
using System.Collections.Generic;

namespace ExtraCollection
{
    public class ListExtensionTest
    {
        [Test]
        public void RemoveIfTest()
        {
            var values1 = new List<int> {1, 2, 3, 4};
            Assert.IsTrue(values1.RemoveIf(it => it % 2 == 0));
            Assert.AreEqual(new[] {1, 3}, values1);

            var values2 = new List<int> {1, 2, 3, 4};
            Assert.IsFalse(values2.RemoveIf(it => it > 4));
            Assert.AreEqual(new[] {1, 2, 3, 4}, values2);

            var values3 = new List<int>();
            Assert.IsFalse(values3.RemoveIf(it => true));
            Assert.IsTrue(values3.Count <= 0);
        }
    }
}