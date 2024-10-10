using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001d)]
    public class Tests20_TransformLocalEverything
    {
        [Test]
        public void TestDefaultValues()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform t = new Transform();

            //Default LocalToWorld Matrix
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalToWorldMatrix.ToArray2D());
            
            //Default WorldToLocal Matrix
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, t.WorldToLocalMatrix.ToArray2D());
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestChangeEverythingEverywhereAllAtOnce()
        {
            //GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            //Order is important when combining matrices together
            //You need to respect the following order : T * R * S
            // T = Translation Matrix
            // R = Rotation Matrix
            // S = Scale Matrix

            Transform t = new Transform();
            t.LocalPosition = new Vector3(1f, 2f, 3f);
            t.LocalRotation = new Vector3(45f, 90f, 30f);
            t.LocalScale = new Vector3(2f, 4f, 6f);
            Assert.AreEqual(new[,]
            {
                { 0.707f, 2.449f, 4.243f, 1.000f },
                { 0.707f, 2.449f, -4.243f, 2.000f },
                { -1.732f, 2.000f, 0.000f, 3.000f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }, t.LocalToWorldMatrix.ToArray2D());
            
            Assert.AreEqual(new[,]
            {
                { 0.177f, 0.177f, -0.433f, 0.768f },
                { 0.153f, 0.153f, 0.125f, -0.834f },
                { 0.118f, -0.118f, 0.000f, 0.118f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }, t.WorldToLocalMatrix.ToArray2D());
            
            //GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}