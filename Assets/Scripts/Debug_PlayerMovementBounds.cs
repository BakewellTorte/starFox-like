using Movement;
using UnityEngine;

namespace MyDebug
{
    public class Debug_PlayerMovementBounds : MonoBehaviour
    {
        [SerializeField]
        private Transform m_topLeftIndicator;

        [SerializeField]
        private Transform m_topRightIndicator;

        [SerializeField]
        private Transform m_bottomLeftIndicator;

        [SerializeField]
        private Transform m_bottomRightIndicator;

        void Start()
        {
            if (Player.Instance == null)
                throw new System.ArgumentNullException("Player.Instance");

            var movementController = Player.Instance.GetComponent<MovementController>();
            m_topLeftIndicator.localPosition = new Vector3(-LevelManager.Instance.Bounds.x, LevelManager.Instance.Bounds.y, 0);
            m_topRightIndicator.localPosition = new Vector3(LevelManager.Instance.Bounds.x, LevelManager.Instance.Bounds.y, 0);
            m_bottomLeftIndicator.localPosition = new Vector3(-LevelManager.Instance.Bounds.x, -LevelManager.Instance.Bounds.y, 0);
            m_bottomRightIndicator.localPosition = new Vector3(LevelManager.Instance.Bounds.x, -LevelManager.Instance.Bounds.y, 0);
        }

        
        void Update()
        {
            transform.position = new Vector3(0, 0, Player.Instance.Position.z);
        }
    }
}