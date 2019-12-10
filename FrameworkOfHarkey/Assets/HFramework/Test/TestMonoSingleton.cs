#if UNITY_EDITOR
using NUnit.Framework;

namespace HFramework
{
    public class TestMonoSingleton
    {
        public class MonoSingletonTest : MonoSingleton<MonoSingletonTest>
        {

        }

        // A Test behaves as an ordinary method
        [Test]
        public void TestMonoSingletonSimplePasses()
        {
            var instanceA = MonoSingletonTest.Instance;
            var instanceB = MonoSingletonTest.Instance;

            Assert.AreEqual(instanceA.GetHashCode(), instanceB.GetHashCode());
        }      
    }
}
#endif
