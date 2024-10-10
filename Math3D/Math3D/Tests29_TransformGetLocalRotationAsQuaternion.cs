using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.01d)]
    public class Tests29_TransformGetLocalRotationAsQuaternion
    {
        [Test]
        public void TestTransformGetLocalRotationQuaternionDefault()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Transform t = new Transform();
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(1f, q.w);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformGetLocalRotationQuaternionXAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 0f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.AreEqual(0.259f, q.x);
            Assert.AreEqual(0f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(0.966f, q.w);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformGetLocalRotationQuaternionYAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 30f, 0f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0.259f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(0.966f, q.w);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformGetLocalRotationQuaternionZAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(0f, 0f, 30f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0f, q.y);
            Assert.AreEqual(0.259f, q.z);
            Assert.AreEqual(0.966f, q.w);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformGetLocalRotationQuaternionMultipleAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();
            t.LocalRotation = new Vector3(30f, 45f, 90f);
            
            Quaternion q = t.LocalRotationQuaternion;
            Assert.AreEqual(0.430f, q.x);
            Assert.AreEqual(0.092f, q.y);
            Assert.AreEqual(0.561f, q.z);
            Assert.AreEqual(0.701f, q.w);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}