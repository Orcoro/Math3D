using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.01d)]
    public class Tests27_QuaternionsMatrix
    {
        [Test]
        public void TestQuaternionMatrixXAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestQuaternionMatrixYAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 1f, 0f));
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, 0f, 0.5f, 0f },
                { 0f, 1f, 0f, 0f },
                { -0.5f, 0f, 0.866f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestQuaternionMatrixZAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.AngleAxis(30f, new Vector3(0f, 0f, 1f));
            
            Assert.AreEqual(new[,]
            {
                { 0.866f, -0.5f, 0f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestQuaternionMatrixMultipleAxis()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion rotationXAxis = Quaternion.AngleAxis(30f, new Vector3(1f, 0f, 0f));
            Quaternion rotationYAxis = Quaternion.AngleAxis(90f, new Vector3(0f, 1f, 0f));

            Quaternion result = rotationXAxis * rotationYAxis;
            Assert.AreEqual(new[,]
            {
                { 0f, 0f, 1f, 0f },
                { 0.5f, 0.866f, 0f, 0f },
                { -0.866f, 0.5f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, result.Matrix.ToArray2D());

            Quaternion invertedResult = rotationYAxis * rotationXAxis;
            Assert.AreEqual(new[,]
            {
                { 0f, 0.5f, 0.866f, 0f },
                { 0f, 0.866f, -0.5f, 0f },
                { -1f, 0f, 0f, 0f },
                { 0f, 0f, 0f, 1f },
            }, invertedResult.Matrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestQuaternionMatrixIdentity()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.01d;

            Quaternion q = Quaternion.Identity;
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, q.Matrix.ToArray2D());

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

    }
}