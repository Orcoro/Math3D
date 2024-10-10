using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.1d)]
    public class Tests30_TransformSetLocalRotationAsQuaternion
    {
        [Test]
        public void TestTransformSetLocalRotationQuaternionXAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0.259f, 0f, 0f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.AreEqual(30f, localRotation.x);
            Assert.AreEqual(0f, localRotation.y);
            Assert.AreEqual(0f, localRotation.z);
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformSetLocalRotationQuaternionYAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0f, 0.259f, 0f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.AreEqual(0f, localRotation.x);
            Assert.AreEqual(30f, localRotation.y);
            Assert.AreEqual(0f, localRotation.z);
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformSetLocalRotationQuaternionZAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0f, 0f, 0.259f, 0.966f);

            Vector3 localRotation = t.LocalRotation;
            Assert.AreEqual(0f, localRotation.x);
            Assert.AreEqual(0f, localRotation.y);
            Assert.AreEqual(30f, localRotation.z);
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestTransformSetLocalRotationQuaternionMultipleAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.1d;
            
            Transform t = new Transform();
            t.LocalRotationQuaternion = new Quaternion(0.430f, 0.092f, 0.561f, 0.701f);
            
            Vector3 localRotation = t.LocalRotation;
            Assert.AreEqual(30f, localRotation.x);
            Assert.AreEqual(45f, localRotation.y);
            Assert.AreEqual(90f, localRotation.z);

            Assert.AreEqual(new[,]
            {
                { 0.353f, -0.707f, 0.612f, 0f },
                { 0.866f, 0.000f, -0.500f, 0f },
                { 0.353f, 0.707f, 0.612f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationXMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0.707f, 0f, 0.707f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.707f, 0f, 0.707f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationYMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0f, -1f, 0f, 0f },
                { 1f, 0f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalRotationZMatrix.ToArray2D());
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}