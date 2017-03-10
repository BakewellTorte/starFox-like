using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class RotationController : MonoBehaviour
    {
        [SerializeField]
        private float m_maxPitchAngle = 60;

        [SerializeField]
        private float m_maxRollAngle = 60;

        [SerializeField]
        private Transform m_roll;

        [SerializeField]
        private Transform m_pitch;

        private MovementController m_movementController;
        void Start()
        {
            if (m_roll == null)
                throw new System.ArgumentNullException("m_roll");

            if (m_pitch == null)
                throw new System.ArgumentNullException("m_pitch");

            m_movementController = GetComponent<MovementController>();
            if (m_movementController == null)
                throw new MissingComponentException("MovementController");
        }

        void Update()
        {
            var rollPercent = m_movementController.VelocityXY.x / m_movementController.MaxXYSpeed;
            m_roll.localRotation = Quaternion.Euler(0, 0, -rollPercent * m_maxRollAngle);

            var pitchPercent = m_movementController.VelocityXY.y / m_movementController.MaxXYSpeed;
            m_pitch.localRotation = Quaternion.Euler(-pitchPercent * m_maxPitchAngle, 0, 0);
        }
    }
}