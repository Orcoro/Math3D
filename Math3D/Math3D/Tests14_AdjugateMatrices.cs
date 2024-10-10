using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    [DefaultFloatingPointTolerance(0.001d)]
    public class Tests14_AdjugateMatrices
    {
        [Test]
        public void TestCalculateAdjugateMatrixInstance()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f },
                { 3f, 4f }
            });

            Matrix<float> adjM = m.Adjugate();
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            Assert.AreEqual(new[,]
            {
                { 4f, -2f },
                { -3f, 1f },
            }, adjM.ToArray2D());
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestCalculateAdjugateMatrixStatic()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 5f },
                { 2f, 1f, 6f },
                { 3f, 4f, 0f },
            });

            Matrix<float> adjM = Matrix<float>.Adjugate(m);

            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            Assert.AreEqual(new[,]
            {
                { -24f, 20f, -5f },
                { 18f, -15f, 4f },
                { 5f, -4f, 1f },
            }, adjM.ToArray2D());
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }

        [Test]
        public void TestCalculateAdjugateMatrixIdentity4x4()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });

            Matrix<float> adjM = m.Adjugate();
            // GlobalSettings.DefaultFloatingPointTolerance = 0.001d;
            Assert.AreEqual(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            }, adjM.ToArray2D());
            // GlobalSettings.DefaultFloatingPointTolerance = 0.0d;
        }
    }
}