using NUnit.Framework;

namespace Maths_Matrices.Tests
{
    [TestFixture]
    public class Tests12_SubMatrices
    {
        [Test]
        public void TestGetSubMatricesInstance()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 6f, 8f, 9f },
                { 17f, 0f, 1f },
                { 23f, 4f, 1f }
            });

            Matrix<float> subMatrix_0_0 = m.SubMatrix(0, 0);
            Assert.AreEqual(new[,]
            {
                { 0f, 1f },
                { 4f, 1f },
            }, subMatrix_0_0.ToArray2D());

            Matrix<float> subMatrix_0_1 = m.SubMatrix(0, 1);
            Assert.AreEqual(new[,]
            {
                { 17f, 1f },
                { 23f, 1f },
            }, subMatrix_0_1.ToArray2D());

            Matrix<float> subMatrix_0_2 = m.SubMatrix(0, 2);
            Assert.AreEqual(new[,]
            {
                { 17f, 0f },
                { 23f, 4f },
            }, subMatrix_0_2.ToArray2D());

            Matrix<float> subMatrix_1_0 = m.SubMatrix(1, 0);
            Assert.AreEqual(new[,]
            {
                { 8f, 9f },
                { 4f, 1f },
            }, subMatrix_1_0.ToArray2D());

            Matrix<float> subMatrix_1_1 = m.SubMatrix(1, 1);
            Assert.AreEqual(new[,]
            {
                { 6f, 9f },
                { 23f, 1f },
            }, subMatrix_1_1.ToArray2D());

            Matrix<float> subMatrix_1_2 = m.SubMatrix(1, 2);
            Assert.AreEqual(new[,]
            {
                { 6f, 8f },
                { 23f, 4f },
            }, subMatrix_1_2.ToArray2D());

            Matrix<float> subMatrix_2_0 = m.SubMatrix(2, 0);
            Assert.AreEqual(new[,]
            {
                { 8f, 9f },
                { 0f, 1f },
            }, subMatrix_2_0.ToArray2D());

            Matrix<float> subMatrix_2_1 = m.SubMatrix(2, 1);
            Assert.AreEqual(new[,]
            {
                { 6f, 9f },
                { 17f, 1f },
            }, subMatrix_2_1.ToArray2D());

            Matrix<float> subMatrix_2_2 = m.SubMatrix(2, 2);
            Assert.AreEqual(new[,]
            {
                { 6f, 8f },
                { 17f, 0f },
            }, subMatrix_2_2.ToArray2D());
        }

        [Test]
        public void TestGetSubMatricesStatic()
        {
            Matrix<float> m = new Matrix<float>(new[,]
            {
                { 1f, 2f, 3f },
                { 4f, 5f, 6f },
                { 7f, 8f, 9f }
            });

            Matrix<float> subMatrix_0_0 = Matrix<float>.SubMatrix(m, 0, 0);
            Assert.AreEqual(new[,]
            {
                { 5f, 6f },
                { 8f, 9f },
            }, subMatrix_0_0.ToArray2D());
            
            Matrix<float> subMatrix_1_2 = Matrix<float>.SubMatrix(m, 1, 0);
            Assert.AreEqual(new[,]
            {
                { 2f, 3f },
                { 8f, 9f },
            }, subMatrix_1_2.ToArray2D());
            
            Matrix<float> subMatrix_2_1 = Matrix<float>.SubMatrix(m, 2, 1);
            Assert.AreEqual(new[,]
            {
                { 1f, 3f },
                { 4f, 6f },
            }, subMatrix_2_1.ToArray2D());
            
            Matrix<float> subMatrix_0_2 = Matrix<float>.SubMatrix(m, 0, 2);
            Assert.AreEqual(new[,]
            {
                { 4f, 5f },
                { 7f, 8f },
            }, subMatrix_0_2.ToArray2D());
        }
    }
}