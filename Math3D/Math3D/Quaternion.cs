using System;
using System.Numerics;


namespace Maths_Matrices
{
    public struct Quaternion
    {
        private Matrix<float> _matrix;
        public float x;
        public float y;
        public float z;
        public float w;

        public Matrix<float> Matrix => _matrix;
        public Vector3 EulerAngles => ToEulerAngles();
        
        public Quaternion()
        {
            x = 0f;
            y = 0f;
            z = 0f;
            w = 1f;
            _matrix = new Matrix<float>(4, 4);
        }
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
            _matrix = new Matrix<float>(4, 4);
            _matrix *= this;
        }
        
        public Quaternion(Quaternion q)
        {
            x = q.x;
            y = q.y;
            z = q.z;
            w = q.w;
            _matrix = q._matrix;
        }

        public static Quaternion Identity => new Quaternion(0f, 0f, 0f, 1f);

        private Vector3 ToEulerAngles()
        {
            Vector3 eulerAngles = new Vector3(0, 0, 0);
            
            // Yaw (Y-axis rotation)
            float siny_cosp = 2 * (w * y + z * x);
            float cosy_cosp = 1 - 2 * (y * y + x * x);
            eulerAngles.y = (float)Math.Atan2(siny_cosp, cosy_cosp);
            
            // Pitch (X-axis rotation)
            float sinp = 2 * (w * x - y * z);
            if (Math.Abs(sinp) >= 1)
                eulerAngles.x = (float)Math.CopySign(Math.PI / 2, sinp); // use 90 degrees if out of range
            else
                eulerAngles.x = (float)Math.Asin(sinp);
            
            // Roll (Z-axis rotation)
            float sinr_cosp = 2 * (w * z + x * y);
            float cosr_cosp = 1 - 2 * (z * z + x * x);
            eulerAngles.z = (float)Math.Atan2(sinr_cosp, cosr_cosp);
            
            RadToDeg(ref eulerAngles);
            
            return eulerAngles;
        }

        private void RadToDeg(ref Vector3 rad)
        {
            rad.x = (float)((rad.x * 180) / Math.PI);
            rad.y = (float)((rad.y * 180) / Math.PI);
            rad.z = (float)((rad.z * 180) / Math.PI);
        }

        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {
            float radians = (float)(Math.PI / 180) * angle;
            float halfAngle = radians / 2;
            float sinHalfAngle = (float)Math.Sin(halfAngle);
            float cosHalfAngle = (float)Math.Cos(halfAngle);

            axis = axis.Normalize();
            Quaternion result = new Quaternion(
                axis.x * sinHalfAngle,
                axis.y * sinHalfAngle,
                axis.z * sinHalfAngle,
                cosHalfAngle
            );
            return result;
        }
        
        public static Quaternion Euler(Vector3 euler)
        {
            Quaternion y = AngleAxis(euler.y, new Vector3(0, 1, 0));
            Quaternion x = AngleAxis(euler.x, new Vector3(1, 0, 0));
            Quaternion z = AngleAxis(euler.z, new Vector3(0, 0, 1));
            Quaternion result = y * x * z;
            return result;
        }
        
        public static Quaternion Euler(float x, float y, float z)
        {
            Quaternion qRY = AngleAxis(y, new Vector3(0, 1, 0));
            Quaternion qRX = AngleAxis(x, new Vector3(1, 0, 0));
            Quaternion qRZ = AngleAxis(z, new Vector3(0, 0, 1));
            Quaternion result = qRY * qRX * qRZ;
            return result;
        }
        
        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            float x = q1.w * q2.x + q1.x * q2.w + q1.y * q2.z - q1.z * q2.y;
            float y = q1.w * q2.y - q1.x * q2.z + q1.y * q2.w + q1.z * q2.x;
            float z = q1.w * q2.z + q1.x * q2.y - q1.y * q2.x + q1.z * q2.w;
            float w = q1.w * q2.w - q1.x * q2.x - q1.y * q2.y - q1.z * q2.z;

            return new Quaternion(x, y, z, w);
        }

        public static Vector3 operator *(Quaternion q, Vector3 v)
        {
            Quaternion p = new Quaternion(v.x, v.y, v.z, 0f);
            Quaternion qInverse = new Quaternion(-q.x, -q.y, -q.z, q.w);
            Quaternion result = q * p * qInverse;

            return new Vector3(result.x, result.y, result.z);
        }
        
        public static Matrix<float> operator *(Matrix<float> m, Quaternion q)
        {
            if (m.NbLines != 4 || m.NbColumns != 4) {
                throw new ArgumentException("Matrix must be 4x4 to multiply by a quaternion.");
            }
            float qx = q.x, qy = q.y, qz = q.z, qw = q.w;
            float[,] qMatrix = new float[4, 4]
            {
                { 1 - 2 * qy * qy - 2 * qz * qz, 2 * qx * qy - 2 * qz * qw, 2 * qx * qz + 2 * qy * qw, 0 },
                { 2 * qx * qy + 2 * qz * qw, 1 - 2 * qx * qx - 2 * qz * qz, 2 * qy * qz - 2 * qx * qw, 0 },
                { 2 * qx * qz - 2 * qy * qw, 2 * qy * qz + 2 * qx * qw, 1 - 2 * qx * qx - 2 * qy * qy, 0 },
                { 0, 0, 0, 1 }
            };
            Matrix<float> result = new Matrix<float>(qMatrix);
            return result;
        }

        public static Matrix<float> operator checked *(Matrix<float> m, Quaternion q)
        {
            throw new NotImplementedException();
        }
    }
}