using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_bounds = new Vector2(10, 5);

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

    public Vector2 Bounds { get { return m_bounds; } }
}
