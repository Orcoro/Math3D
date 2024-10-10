using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.01d)]
    public class Tests25_QuaternionsMultiplication
    {
        [Test]
        public void TestQuaternionMultiplyXAxisAndYAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationYAxis * rotationXAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(-0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestQuaternionMultiplyXAxisAndZAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationXAxis = Quaternion.AngleAxis(90f, new Vector3(1f, 0f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationXAxis * rotationZAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(-0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationXAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestQuaternionMultiplyYAxisAndZAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion rotationZAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 0f, 1f));

            Quaternion result = rotationYAxis * rotationZAxis;
            Assert.AreEqual(0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            result = rotationZAxis * rotationYAxis;
            Assert.AreEqual(-0.5f, result.x);
            Assert.AreEqual(0.5f, result.y);
            Assert.AreEqual(0.5f, result.z);
            Assert.AreEqual(0.5f, result.w);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestQuaternionMultiplyIdentity()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));
            Quaternion qIdentity = Quaternion.Identity;

            Quaternion result = rotationYAxis * qIdentity;
            Assert.AreEqual(0f, result.x);
            Assert.AreEqual(0.71f, result.y);
            Assert.AreEqual(0f, result.z);
            Assert.AreEqual(0.71f, result.w);

            result = qIdentity * rotationYAxis;
            Assert.AreEqual(0f, result.x);
            Assert.AreEqual(0.71f, result.y);
            Assert.AreEqual(0f, result.z);
            Assert.AreEqual(0.71f, result.w);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}