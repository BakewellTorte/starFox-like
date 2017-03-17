using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_path;

    [SerializeField]
    private Transform m_trigger;

    [SerializeField]
    private Enemy_PathFollower m_enemyPrefab;

    void Awake()
    {
        if (LevelManager.Instance == null)
            throw new System.ArgumentNullException("LevelManager");
        m_trigger.localScale = new Vector3(LevelManager.Instance.Bounds.x, LevelManager.Instance.Bounds.y, 1);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            var enemy = Instantiate(m_enemyPrefab) as Enemy_PathFollower;
            enemy.Initialise(Path);
        }
    }

    public List<Transform> Path
    {
        get
        {
            return m_path;
        }
    }

    public Transform Trigger
    {
        get
        {
            return m_trigger;
        }
    }
}
