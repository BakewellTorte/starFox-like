using UnityEngine;

namespace Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField]
        private float m_maxXYSpeed = 10;

        [SerializeField]
        private float m_zSpeed = 0;

        [Space]
        [SerializeField]
        private float m_smoothDampTime = 1;
       
        void Update()
        {
            Move(GetHorizontalAndVerticalInput());
        }

        private Vector3 m_smoothDampCurrentVelocity;
        private void Move(Vector3 direction)
        {
            if (direction.z != 0)
                throw new System.ArgumentOutOfRangeException("direction.z", "Value must be 0");

            var targetVelocity = m_maxXYSpeed * direction;

            VelocityXY = Vector3.SmoothDamp(VelocityXY, targetVelocity, ref m_smoothDampCurrentVelocity, m_smoothDampTime);

            Position += (VelocityXY + VelocityZ) * Time.deltaTime;
        }

        /// <summary>
        /// Gets Horizontal and Vertical Input
        /// </summary>
        /// <returns>Normalised Vector3 indicating horizontal and vertical input</returns>
        private Vector3 GetHorizontalAndVerticalInput()
        {
            var hInput = Input.GetAxis("Horizontal");
            var vInput = Input.GetAxis("Vertical");

            return new Vector3(hInput, vInput, 0).normalized;
        }

        public Vector3 Position
        {
            get { return transform.position; }
            private set
            {
                var xPos = Mathf.Clamp(value.x, -LevelManager.Instance.Bounds.x, LevelManager.Instance.Bounds.x);
                var yPos = Mathf.Clamp(value.y, -LevelManager.Instance.Bounds.y, LevelManager.Instance.Bounds.y);

                transform.position = new Vector3(xPos, yPos, value.z);
            }
        }

        private Vector3 m_velocity;
        public Vector3 VelocityXY
        {
            get { return m_velocity; }
            private set { m_velocity = Vector3.ClampMagnitude(value, m_maxXYSpeed); }
        }

        public Vector3 VelocityZ
        {
            get { return m_zSpeed * Vector3.forward; }
        }

        public float MaxXYSpeed
        {
            get { return m_maxXYSpeed; }
        }
    }
}