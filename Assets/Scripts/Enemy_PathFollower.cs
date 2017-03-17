using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_PathFollower : MonoBehaviour
{
    [SerializeField]
    private float m_maxSpeed = 1;

    [SerializeField]
    private float m_minProximityToWaypoint = 0.1f;

    [SerializeField]
    private Rigidbody m_rigidbody;

    void Awake()
    {
        m_rigidbody.useGravity = false;
        m_rigidbody.isKinematic = false;
    }

    private List<Transform> m_path;
    public void Initialise(List<Transform> path)
    {
        if (path == null)
            throw new System.ArgumentNullException("path");

        if (path.Count <= 1)
            throw new System.ArgumentOutOfRangeException("path", "Length must be at least 2");

        m_path = path;

        transform.position = m_path[0].position;        
        transform.LookAt(m_path[1].position);
    }

    private int m_nextWaypointIndex = 1;
    void FixedUpdate()
    {
        if (m_path == null) return;

        var toDestination = m_path[m_nextWaypointIndex].position - transform.position;
        if (toDestination.sqrMagnitude > m_minProximityToWaypoint * m_minProximityToWaypoint)
        {
            var desiredVelocity = m_maxSpeed * toDestination.normalized;

            var steeringForce = desiredVelocity - m_rigidbody.velocity;
            print(steeringForce.magnitude);
            m_rigidbody.AddForce(steeringForce);
        }
        else
        {            
            m_nextWaypointIndex++;
            if (m_nextWaypointIndex == m_path.Count) gameObject.SetActive(false);
        }

        if(m_rigidbody.velocity != Vector3.zero) m_rigidbody.rotation = Quaternion.LookRotation(m_rigidbody.velocity);
    }
}
