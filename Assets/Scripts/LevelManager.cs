using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 m_bounds = new Vector3(10, 5, 100);

    public static LevelManager Instance = null;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.ArgumentException("LevelManager.Instance", "Multiple LevelManager(s) found in scene");
        }
    }

    public Vector3 Bounds { get { return m_bounds; } }
}
