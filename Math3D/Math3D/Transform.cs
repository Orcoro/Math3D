namespace Maths_Matrices
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normalize()
        {
            float magnitude = Magnitude();
            
            if (magnitude > 0) {
                return new Vector3(x / magnitude, y / magnitude, z / magnitude);
            }
            return new Vector3(0, 0, 0);
        }
        
        public Matrix<float> GetMatrix()
        {
            return new Matrix<float>(new[,]
            {
                { x },
                { y },
                { z }
            });
        }
        
        public static Vector3 operator *(Matrix<float> m, Vector3 v)
        {
            return new Vector3(
                m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z,
                m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z,
                m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z
            );
        }
        
        public static Vector3 operator *(Vector3 v, float f)
        {
            return new Vector3(v.x * f, v.y * f, v.z * f);
        }
        
        public static Vector3 operator *(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }
        
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        
        #region Cast

        public static explicit operator Vector3(Vector4 v)
        {
            return new Vector3(v.x, v.y, v.z);
        }
        
        public static explicit operator Vector3(Matrix<float> m)
        {
            return new Vector3(m[0, 0], m[1, 0], m[2, 0]);
        }
        #endregion //Cast
    }
    public class Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static Vector4 operator *(Matrix<float> m, Vector4 v)
        {
            return new Vector4(
                m[0, 0] * v.x + m[0, 1] * v.y + m[0, 2] * v.z + m[0, 3] * v.w,
                m[1, 0] * v.x + m[1, 1] * v.y + m[1, 2] * v.z + m[1, 3] * v.w,
                m[2, 0] * v.x + m[2, 1] * v.y + m[2, 2] * v.z + m[2, 3] * v.w,
                m[3, 0] * v.x + m[3, 1] * v.y + m[3, 2] * v.z + m[3, 3] * v.w
            );
        }
    }

    public class Transform
    {
        private Transform _parent;
        private Vector3 _worldPosition = new Vector3(0f, 0f, 0f);
        private Vector3 _localPosition = new Vector3(0f, 0f, 0f);
        private Vector3 _localRotation = new Vector3(0f, 0f, 0f);
        private Vector3 _localScale = new Vector3(1f, 1f, 1f);
        private Quaternion _quaternion = new Quaternion(0f, 0f, 0f, 1f);
        private Matrix<float> _localToWorldMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _worldToLocalMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _localTranslationMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _localRotationXMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _localRotationYMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _localRotationZMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _localRotationMatrix = Matrix<float>.Identity(4);
        private Matrix<float> _localScaleMatrix = Matrix<float>.Identity(4);

        #region Properties
        public Transform Parent
        {
            get => _parent;
        }
        
        public Vector3 WorldPosition
        {
            get => _worldPosition;
            set => SetWorldPosition(value);
        }
        public Vector3 LocalPosition
        {
            get => _localPosition;
            set => SetLocalPosition(value);
        }
        public Vector3 LocalRotation
        {
            get => _localRotation;
            set => SetLocalRotation(value);
        }
        public Vector3 LocalScale
        {
            get => _localScale;
            set => SetLocalScale(value);
        }
        public Matrix<float> LocalToWorldMatrix
        {
            get => _localToWorldMatrix;
            set => SetLocalToWorldMatrix(value);
        }
        public Matrix<float> WorldToLocalMatrix
        {
            get => _worldToLocalMatrix;
        }
        
        public Quaternion LocalRotationQuaternion
        {
            get => _quaternion;
            set => SetQuaternion(value);
        }
        
        public Matrix<float> LocalTranslationMatrix { get => _localTranslationMatrix; set => _localTranslationMatrix = value; }
        public Matrix<float> LocalRotationXMatrix { get => _localRotationXMatrix; set => _localRotationXMatrix = value; }
        public Matrix<float> LocalRotationYMatrix { get => _localRotationYMatrix; set => _localRotationYMatrix = value; }
        public Matrix<float> LocalRotationZMatrix { get => _localRotationZMatrix; set => _localRotationZMatrix = value; }
        public Matrix<float> LocalRotationMatrix { get => _localRotationMatrix; set => _localRotationMatrix = value; }
        public Matrix<float> LocalScaleMatrix { get => _localScaleMatrix; set => _localScaleMatrix = value; }
        #endregion //Properties

        #region Constructors
        public Transform()
        {
            _worldPosition = new Vector3(0f, 0f, 0f);
            _worldToLocalMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            _localPosition = new Vector3(0f, 0f, 0f);
            LocalTranslationMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            _localRotation = new Vector3(0f, 0f, 0f);
            LocalRotationXMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            LocalRotationYMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            LocalRotationZMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            LocalRotationMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            _localScale = new Vector3(1f, 1f, 1f);
            LocalScaleMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
            _localToWorldMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, 0f },
                { 0f, 1f, 0f, 0f },
                { 0f, 0f, 1f, 0f },
                { 0f, 0f, 0f, 1f },
            });
        }

        public Transform(float x, float y, float z, float w) : this()
        {
            LocalPosition = new Vector3(x, y, z);
            LocalTranslationMatrix = new Matrix<float>(new[,]
            {
                { 1f, 0f, 0f, x },
                { 0f, 1f, 0f, y },
                { 0f, 0f, 1f, z },
                { 0f, 0f, 0f, w },
            });
        }
        #endregion

        #region Public Methods
        public void SetParent(Transform parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            _parent = parent;
            SetLocalToWorldMatrix();
            
        }
        #endregion //Public Methods
        
        #region Private Methods
        private void SetQuaternion(Quaternion quaternion)
        {
            _quaternion = quaternion;
            SetLocalRotation(quaternion.EulerAngles);
        }
        
        #region Local Position
        private void SetLocalPosition(Vector3 position)
        {
            _localPosition = position;
            _localTranslationMatrix[0, 3] = position.x;
            _localTranslationMatrix[1, 3] = position.y;
            _localTranslationMatrix[2, 3] = position.z;
            SetLocalToWorldMatrix();
        }

        private void SetLocalPosition()
        {
            if (_parent == null) {
                _localPosition.x = _localToWorldMatrix[0, 3];
                _localPosition.y = _localToWorldMatrix[1, 3];
                _localPosition.z = _localToWorldMatrix[2, 3];
            } else {
                _localPosition.x = _worldToLocalMatrix[0, 3];
                _localPosition.y = _worldToLocalMatrix[1, 3];
                _localPosition.z = _worldToLocalMatrix[2, 3];
            }
        }

        #endregion //Local Position
        
        #region Local Rotation
        private void SetLocalRotation(Vector3 rotation)
        {
            if (rotation.y != _localRotation.y) {
                SetLocalRotationY(rotation);
            }
            if (rotation.x != _localRotation.x) {
                SetLocalRotationX(rotation);
            }
            if (rotation.z != _localRotation.z) {
                SetLocalRotationZ(rotation);
            }
            _localRotation = rotation;
            _localRotationMatrix = _localRotationYMatrix * _localRotationXMatrix * _localRotationZMatrix;
            _quaternion = Quaternion.Euler(_localRotation);
            SetLocalToWorldMatrix();
        }
        
        private void SetLocalRotationX(Vector3 rotation)
        {
            float radians = rotation.x * (float)(Math.PI / 180.0);
            _localRotationXMatrix[1, 1] = (float)Math.Cos(radians);
            _localRotationXMatrix[1, 2] = -(float)Math.Sin(radians);
            _localRotationXMatrix[2, 1] = (float)Math.Sin(radians);
            _localRotationXMatrix[2, 2] = (float)Math.Cos(radians);
        }
        
        private void SetLocalRotationY(Vector3 rotation)
        {
            float radians = rotation.y * (float)(Math.PI / 180.0);
            _localRotationYMatrix[0, 0] = (float)Math.Cos(radians);
            _localRotationYMatrix[0, 2] = (float)Math.Sin(radians);
            _localRotationYMatrix[2, 0] = -(float)Math.Sin(radians);
            _localRotationYMatrix[2, 2] = (float)Math.Cos(radians);
        }
        
        private void SetLocalRotationZ(Vector3 rotation)
        {
            float radians = rotation.z * (float)(Math.PI / 180.0);
            _localRotationZMatrix[0, 0] = (float)Math.Cos(radians);
            _localRotationZMatrix[0, 1] = -(float)Math.Sin(radians);
            _localRotationZMatrix[1, 0] = (float)Math.Sin(radians);
            _localRotationZMatrix[1, 1] = (float)Math.Cos(radians);
        }
        #endregion //Local Rotation

        #region Local Scale
        private void SetLocalScale(Vector3 scale)
        {
            _localScale = scale;
            _localScaleMatrix[0, 0] = scale.x;
            _localScaleMatrix[1, 1] = scale.y;
            _localScaleMatrix[2, 2] = scale.z;
            SetLocalToWorldMatrix();
        }
        #endregion
        
        #region LocalToWorldMatrix
        private void SetLocalToWorldMatrix(Matrix<float> matrix)
        {
            _localToWorldMatrix = matrix;
        }
        
        private void SetLocalToWorldMatrix()
        {
            Matrix<float> result = _localTranslationMatrix * _localRotationMatrix * _localScaleMatrix;
            if (_parent != null) {
                result = _parent.LocalToWorldMatrix * result;
            }
            _localToWorldMatrix = result;
            _worldToLocalMatrix = _localToWorldMatrix.InvertByRowReduction();
            SetWorldPosition();
        }
        #endregion //LocalToWorldMatrix
        
        #region WorldToLocalMatrix
        private void SetWorldToLocalMatrix()
        {
            _worldToLocalMatrix = _localToWorldMatrix.InvertByRowReduction();
        }
        #endregion //WorldToLocalMatrix
        
        #region World Position
        private void SetWorldPosition(Vector3 position)
        {
            _localToWorldMatrix[0, 3] = position.x;
            _localToWorldMatrix[1, 3] = position.y;
            _localToWorldMatrix[2, 3] = position.z;
            SetLocalPosition();
        }
        private void SetWorldPosition()
        {
            _worldPosition.x = _localToWorldMatrix[0, 3];
            _worldPosition.y = _localToWorldMatrix[1, 3];
            _worldPosition.z = _localToWorldMatrix[2, 3];
        }
        #endregion //World Position
        #endregion //Private Methods 
    }
}
