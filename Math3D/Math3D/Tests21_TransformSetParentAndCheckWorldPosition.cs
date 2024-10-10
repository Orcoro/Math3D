using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001d)]
    public class Tests21_TransformSetParentAndCheckWorldPosition
    {
        [Test]
        public void TestParentChangePosition()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(10f, 5f, 2f);

            Transform tChild = new Transform();
            tChild.SetParent(tParent);
        
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 5f },
                { 0f, 0f, 1f, 2f },
                { 0f, 0f, 0f, 1f },
            }, tParent.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(10f, tParent.WorldPosition.x);
            Assert.AreEqual(5f, tParent.WorldPosition.y);
            Assert.AreEqual(2f, tParent.WorldPosition.z);
            
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 5f },
                { 0f, 0f, 1f, 2f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(10f, tChild.WorldPosition.x);
            Assert.AreEqual(5f, tChild.WorldPosition.y);
            Assert.AreEqual(2f, tChild.WorldPosition.z);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestDoubleParentChangePosition()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;

            //tRoot (10,5,2)
            //  -> tParent (1,4,42) => (11,9,44)
            //      -> tChild (1,2,3) => (12,11,47)
            
            Transform tRoot = new Transform();
            tRoot.LocalPosition = new Vector3(10f, 5f, 2f);

            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(1f, 4f, 42f);
            tParent.SetParent(tRoot);

            Transform tChild = new Transform();
            tChild.LocalPosition = new Vector3(-1f, 2f, 3f);
            tChild.SetParent(tParent);
            
            //Check tParent Matrix and World Position
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 11f },
                { 0f, 1f, 0f, 9f },
                { 0f, 0f, 1f, 44f },
                { 0f, 0f, 0f, 1f },
            }, tParent.LocalToWorldMatrix.ToArray2D());
            
            Assert.AreEqual(11f, tParent.WorldPosition.x);
            Assert.AreEqual(9f, tParent.WorldPosition.y);
            Assert.AreEqual(44f, tParent.WorldPosition.z);
        
            //Check tChild Matrix and World Position
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 10f },
                { 0f, 1f, 0f, 11f },
                { 0f, 0f, 1f, 47f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());
            
            Assert.AreEqual(10f, tChild.WorldPosition.x);
            Assert.AreEqual(11f, tChild.WorldPosition.y);
            Assert.AreEqual(47f, tChild.WorldPosition.z);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestParentChangePositionAndRotation()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(10f, 5f, 2f);
            tParent.LocalRotation = new Vector3(0f, 0f, 45f);

            Transform tChild = new Transform();
            tChild.LocalPosition = new Vector3(1f, 0f, 0f);
            tChild.SetParent(tParent);
        
            Assert.AreEqual(new[,]
            {
                { 0.707f, -0.707f, 0.000f, 10.707f },
                { 0.707f, 0.707f, 0.000f, 5.707f },
                { 0.000f, 0.000f, 1.000f, 2.000f },
                { 0.000f, 0.000f, 0.000f, 1.000f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(10.707f, tChild.WorldPosition.x);
            Assert.AreEqual(5.707f, tChild.WorldPosition.y);
            Assert.AreEqual(2f, tChild.WorldPosition.z);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
        
        [Test]
        public void TestParentChangePositionAndScale()
        {
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            
            Transform tParent = new Transform();
            tParent.LocalPosition = new Vector3(100f, 0f, -20f);
            tParent.LocalScale = new Vector3(2f, 4f, 6f);

            Transform tChild = new Transform();
            tChild.LocalPosition = new Vector3(1f, 1f, 1f);
            tChild.SetParent(tParent);
        
            Assert.AreEqual(new[,]
            {
                { 2f, 0f, 0f, 102f },
                { 0f, 4f, 0f, 4f },
                { 0f, 0f, 6f, -14f },
                { 0f, 0f, 0f, 1f },
            }, tChild.LocalToWorldMatrix.ToArray2D());

            Assert.AreEqual(102f, tChild.WorldPosition.x);
            Assert.AreEqual(4f, tChild.WorldPosition.y);
            Assert.AreEqual(-14f, tChild.WorldPosition.z);
            
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}
