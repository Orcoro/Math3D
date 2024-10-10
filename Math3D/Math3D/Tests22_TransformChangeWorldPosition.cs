using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001d)]
    public class Tests22_TransformChangeWorldPosition
    {
        [Test]
        public void TestChangeWorldPosition()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform t = new Transform();
            t.WorldPosition = new Vector3(100f, 1f, 42f);

            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 100f },
                { 0f, 1f, 0f, 1f },
                { 0f, 0f, 1f, 42f },
                { 0f, 0f, 0f, 1f },
            }, t.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(100f, t.LocalPosition.x);
            Assert.AreEqual(1f, t.LocalPosition.y);
            Assert.AreEqual(42f, t.LocalPosition.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestChangeWorldPositionInsideParent()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(100f, 1f, 42f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(-100f, tChild.LocalPosition.x);
            Assert.AreEqual(-1f, tChild.LocalPosition.y);
            Assert.AreEqual(-42f, tChild.LocalPosition.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestChangeWorldPositionInsideParentWithRotation()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(20f, 0f, 0f);
            tParent.LocalRotation = new Vector3(0f, 0f, 45f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            Assert.AreEqual(new[,]
            {
                { 0.707f, -0.707f, 0f, 0f },
                { 0.707f, 0.707f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(-14.142f, tChild.LocalPosition.x);
            Assert.AreEqual(14.142f, tChild.LocalPosition.y);
            Assert.AreEqual(0f, tChild.LocalPosition.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestChangeWorldPositionInsideParentWithScale()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(200, -10f, 9f);
            tParent.LocalScale = new Vector3(2f, 4f, 6f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
            tChild.WorldPosition = new Vector3(0f, 0f, 0f);

            Assert.AreEqual(new[,]
            {
                { 2f, 0f, 0f, 0f },
                { 0f, 4f, 0f, 0f },
                { 0f, 0f, 6f, 0f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(-100f, tChild.LocalPosition.x);
            Assert.AreEqual(2.5f, tChild.LocalPosition.y);
            Assert.AreEqual(-1.5f, tChild.LocalPosition.z);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}