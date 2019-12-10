using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace HFramework
{
    public class TestSingleton
    {
        public class SingletonTest : Singleton<SingletonTest>
        {
            private SingletonTest() { }
        }
        [Test]
        public void TestSingletonSimplePasses()
        {
            var instanceA = SingletonTest.Instance;
            var instanceB = SingletonTest.Instance;

            Assert.AreEqual(instanceA.GetHashCode(), instanceB.GetHashCode());
        }

        
    }
}
