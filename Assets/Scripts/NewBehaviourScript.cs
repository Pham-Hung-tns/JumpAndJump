using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{

    //load scene 1
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSceneMain()
    {
        SceneManager.LoadScene(1);
        PlayerManager.lastCheckPoint = new Vector2(-18.25f, -2.38f);
        Time.timeScale = 1;
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
