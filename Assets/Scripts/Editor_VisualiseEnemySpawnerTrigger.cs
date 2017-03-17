using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Editor_VisualiseEnemySpawnerTrigger : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner m_spawner;

    private LevelManager m_levelManager;
    void Update()
    {
        if (m_spawner == null) return;

        if(m_levelManager == null)
        {
            var levelManagerGameObject = GameObject.Find("LevelManagement");
            if (levelManagerGameObject == null)
                throw new System.ArgumentNullException("levelManagerGameObject");

            m_levelManager = levelManagerGameObject.GetComponent<LevelManager>();
            if (m_levelManager == null)
                throw new MissingComponentException("LevelManager");
        }
        print("BLAH");
        m_spawner.Trigger.localScale = new Vector3(m_levelManager.Bounds.x, m_levelManager.Bounds.y, 1);
    }
}
