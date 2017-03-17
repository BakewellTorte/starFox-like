using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Editor_VisualiseEnemySpawnerPath : MonoBehaviour
{
    [SerializeField]
    private LineRenderer m_lineRenderer;

    [SerializeField]
    private EnemySpawner m_spawner;    

    void Update()
    {        
        if (m_lineRenderer == null)
        {
            print(string.Format("({0}): Line Renderer is null", ToString()));
            return;
        }

        if(m_spawner == null)
        {
            print(string.Format("({0}): Spawner is null", ToString()));
            return;
        }

        print("Updating Path");
        
        if(m_spawner.Path.Count > 0)
        {
            m_lineRenderer.numPositions = m_spawner.Path.Count;
            for (int i = 0; i < m_spawner.Path.Count; i++)
            {                
                m_lineRenderer.SetPosition(i, m_spawner.Path[i].position);
            }
        }        
    }
}
