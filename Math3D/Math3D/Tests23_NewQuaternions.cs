using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests23_NewQuaternions
    {
        [Test]
        public void TestNewQuaternion()
        {
            Quaternion q = new Quaternion(0f, 0.71f, 0f, 0.71f);
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0.71f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(0.71f, q.w);
        }
        
        [Test]
        public void TestNewQuaternionFromAnother()
        {
            Quaternion q1 = new Quaternion(0f, 0.71f, 0f, 0.71f);
            Quaternion q2 = q1;
            q2.x = 0.71f;

            Assert.AreEqual(0.71f, q2.x);
            Assert.AreEqual(0.71f, q2.y);
            Assert.AreEqual(0f, q2.z);
            Assert.AreEqual(0.71f, q2.w);
            
            Assert.AreEqual(0f, q1.x);
            Assert.AreEqual(0.71f, q1.y);
            Assert.AreEqual(0f, q1.z);
            Assert.AreEqual(0.71f, q1.w);
        }
        
        [Test]
        public void TestQuaternionIdentity()
        {
            //An identity quantity is a quaternion with no rotation
            Quaternion q = Quaternion.Identity;
            Assert.AreEqual(0f, q.x);
            Assert.AreEqual(0f, q.y);
            Assert.AreEqual(0f, q.z);
            Assert.AreEqual(1f, q.w);
        }
    }
}