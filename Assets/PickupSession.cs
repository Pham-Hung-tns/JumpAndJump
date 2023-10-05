using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSession : MonoBehaviour
{
    void Awake()
    {
        int pickUpSession = FindObjectsOfType<PickupSession>().Length;
        if (pickUpSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void RestartScene()
    {
        Destroy(gameObject);
    }
    
}
