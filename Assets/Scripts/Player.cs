using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance = null;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.ArgumentException("Player.Instance", "Multiple Player(s) found in scene");
        }
    }
    
    public Vector3 Position
    {
        get { return transform.position; }        
    }
}
