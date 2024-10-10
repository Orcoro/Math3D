using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001d)]
    public class Tests19_TransformLocalScale
    {
        [Test]
        public void TestDefaultValues()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Default Scale
            Assert.AreEqual(1f, t.LocalScale.x);
            Assert.AreEqual(1f, t.LocalScale.y);
            Assert.AreEqual(1f, t.LocalScale.z);
            
            //Default Matrix
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestChangeScale()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Scale X
            t.LocalScale = new Vector3(2f, 1f, 1f);
            Assert.AreEqual(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //Scale Y
            t.LocalScale = new Vector3(1f, 5f, 1f);
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 5f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            //Scale Z
            t.LocalScale = new Vector3(1f, 1f, 23f);
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 23f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalScaleMatrix.ToArray2D());
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}