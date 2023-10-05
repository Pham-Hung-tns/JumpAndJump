using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class PlayerManager : MonoBehaviour
{

    public GameObject[] playerPrefabs;
    int characterIndex;
    public static Vector2 lastCheckPoint = new Vector2(-18.25f, -2.38f);
    public CinemachineStateDrivenCamera cm;

    void Awake()
    {
        
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject player = Instantiate(playerPrefabs[characterIndex], lastCheckPoint, Quaternion.identity);
        cm.m_Follow = player.transform;
        cm.m_AnimatedTarget = player.GetComponent<Animator>();
    }
}
