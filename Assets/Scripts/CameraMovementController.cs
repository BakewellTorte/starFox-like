using UnityEngine;

public class CameraMovementController : MonoBehaviour
{    
    [SerializeField]
    private float m_offsetFromBoundsX = 10;

    [SerializeField]
    private float m_offsetFromBoundsY = 5;

    [SerializeField]
    private float m_zOffsetFromPlayer = 10;

    [SerializeField]
    private float m_smoothDampTime = 1;

    void Start()
    {        
        if (Player.Instance == null)
            throw new System.ArgumentNullException("Player.Instance");

        transform.position = Player.Instance.Position + m_zOffsetFromPlayer * Vector3.back;
    }

    private Vector3 m_smoothDampCurrentVelocity;
    void LateUpdate()
    {
        TargetXYPosition = Player.Instance.Position;
        var position = Vector3.SmoothDamp(XYPosition, TargetXYPosition, ref m_smoothDampCurrentVelocity, m_smoothDampTime);
        position = new Vector3(position.x, position.y, Player.Instance.Position.z - m_zOffsetFromPlayer);
        transform.position = position;
    }

    private Vector3 m_targetPosition;
    private Vector3 TargetXYPosition
    {
        get { return m_targetPosition; }
        set
        {
            var xPos = Mathf.Clamp(value.x, -LevelManager.Instance.Bounds.x + m_offsetFromBoundsX, LevelManager.Instance.Bounds.x - m_offsetFromBoundsX);
            var yPos = Mathf.Clamp(value.y, -LevelManager.Instance.Bounds.y + m_offsetFromBoundsY, LevelManager.Instance.Bounds.y - m_offsetFromBoundsY);

            m_targetPosition = new Vector3(xPos, yPos, 0);
        }
    }

    private Vector3 XYPosition
    {
        get { return new Vector3(transform.position.x, transform.position.y, 0); }
    }
}