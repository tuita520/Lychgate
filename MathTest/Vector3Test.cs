using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sigon.Math;

namespace Sigon.Test.Math
{
    [TestClass]
    public class Vector3Test
    {
        [TestMethod]
        public void TestConstructorStd()
        {
            Vector3 vec = new Vector3();
            Assert.AreEqual(vec.X, 0.0d);
            Assert.AreEqual(vec.Y, 0.0d);
            Assert.AreEqual(vec.Z, 0.0d);
        }

        [TestMethod]
        public void TestConstructorArgs()
        {
            Vector3 vec = new Vector3(1.0d, 1.0d, 1.0d);
            Assert.AreEqual(vec.X, 1.0d);
            Assert.AreEqual(vec.Y, 1.0d);
            Assert.AreEqual(vec.Z, 1.0d);
        }
    }
}
