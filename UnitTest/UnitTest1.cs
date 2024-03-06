using NUnit.Framework;
using rubrik.Models;
using System.Collections.Generic;

namespace Rubrik_test
{
    public class Tests
    {
        Cube testCube;
        [SetUp]
        public void Setup()
        {
            testCube = new Cube();
            testCube.setDefaultCubeColours();
        }

        [Test]
        public void TestRotate()
        {
            testCube.RotateFace(testCube.UFace, true);

            Assert.IsTrue(testCube.BFace.TRFace == "Orange");
            Assert.IsTrue(testCube.BFace.TMFace == "Orange");
            Assert.IsTrue(testCube.BFace.TLFace == "Orange");
            Assert.IsTrue(testCube.BFace.MRFace == "Blue");
            Assert.IsTrue(testCube.BFace.MMFace == "Blue");
            Assert.IsTrue(testCube.BFace.MLFace == "Blue");
        }
        [Test]
        public void TestRotateAntiClockwise()
        {
            testCube.RotateFace(testCube.UFace, false);

            Assert.IsTrue(testCube.BFace.TRFace == "Red");
            Assert.IsTrue(testCube.BFace.TMFace == "Red");
            Assert.IsTrue(testCube.BFace.TLFace == "Red");
            Assert.IsTrue(testCube.BFace.MRFace == "Blue");
            Assert.IsTrue(testCube.BFace.MMFace == "Blue");
            Assert.IsTrue(testCube.BFace.MLFace == "Blue");
        }
        //i could test more situations and the whole cube, but i just wanted dot make sure it rotates here.
    }
}