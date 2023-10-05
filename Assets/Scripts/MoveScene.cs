using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveScene : MonoBehaviour
{
    [SerializeField] float delayLoad = 1f;
    [SerializeField] Transform posOnNewScene;
    PlayerManager player;
    int countCoins;
    int countCoinsInScene = 0;
    Session getCoins;
    private void Start()
    {
        getCoins = FindObjectOfType<Session>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player") && (getCoins.GetScore() % 60 == 0)) 
        {
            StartCoroutine(LoadNextLevel());       
        }
    }
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(delayLoad);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            FindObjectOfType<ButtonControl>().finalGame();
        }
        else
        {
            FindObjectOfType<PickupSession>().RestartScene();
            Destroy(FindObjectOfType<AudioSource>());
            SceneManager.LoadScene(nextSceneIndex);
            PlayerManager.lastCheckPoint = posOnNewScene.position;
        }
        
    }
}
