using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    [SerializeField] GameObject panelPauseGame;
    [SerializeField] GameObject panelPlayAgain;
    [SerializeField] GameObject panelEndGame;
    [SerializeField] GameObject panelFinalGame;
    //[SerializeField] GameObject playerActive;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SoundManager>().playMusic();
    }

    // button pause game
    public void PauseGame()
    {
        Time.timeScale = 0;
        FindObjectOfType<SoundManager>().pauseMusic();
    }
    // move to scene 0
    public void GotoMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<PickupSession>().RestartScene();
        FindObjectOfType<Session>().DestroyGameObject();
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        FindObjectOfType<SoundManager>().playMusic();
    }
    public void playAgain()
    {
        panelPlayAgain.SetActive(true);
        panelPauseGame.SetActive(false);
        Time.timeScale = 0;
        FindObjectOfType<SoundManager>().pauseMusic();
    }
    public void playAgainButton()
    {
        FindObjectOfType<Session>().Life();
        Time.timeScale = 1;
        panelPlayAgain.SetActive(false);
        panelPauseGame.SetActive(true);
        FindObjectOfType<SoundManager>().playMusic();
    }
    public void endGame()
    {
        Time.timeScale = 0;
        panelEndGame.SetActive(true);
        panelPauseGame.SetActive(false);
        FindObjectOfType<SoundManager>().stopMusic();
        
    }
    public void finalGame()
    {
        Time.timeScale = 0;
        panelFinalGame.SetActive(true);
        panelPauseGame.SetActive(false);
        FindObjectOfType<SoundManager>().stopMusic();
        
    }
}
