using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Editor_VisualiseLevelBounds : MonoBehaviour
{
    [SerializeField]
    private Transform m_display;

    [SerializeField]
    private LevelManager m_levelManager;

    private Vector3 m_prevBounds;
    void Update()
    {
        if (m_levelManager == null)
        {
            print(string.Format("({0}): Level Manager is null", ToString()));
            return;
        }

        if (m_display == null)
        {
            print(string.Format("({0}): Display is null", ToString()));
            return;
        }

        if (m_prevBounds != m_levelManager.Bounds) UpdateDisplay();
    }


    private void UpdateDisplay()
    {
        m_display.localPosition = new Vector3(0, 0, 0.5f * m_levelManager.Bounds.z);
        m_display.localScale = m_levelManager.Bounds;

        m_prevBounds = m_levelManager.Bounds;
    }
}
