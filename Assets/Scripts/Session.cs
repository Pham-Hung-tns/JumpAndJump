using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Session : MonoBehaviour
{
    [SerializeField] int playerLife = 2;
    [SerializeField] TextMeshProUGUI pointNumber;
    [SerializeField] TextMeshProUGUI liveText;
    [SerializeField] int score = 0;
    void Awake()
    {

        // khi restart mot man choi, de tranh truong hop tao ra qua nhieu Gameobject session, check dieu kien de xoa
        int GameSession = FindObjectsOfType<Session>().Length;
        if (GameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // khi restart mot man choi, giu nguyen Gameobject session
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        liveText.text = playerLife.ToString();
        pointNumber.text = score.ToString();
    }

    public void AddScore(int scorepoint)
    {
        score += scorepoint;
        pointNumber.text = score.ToString();
    }
    public int GetScore()
    {
        return score;
    }
    public void ProcessPlayerIsDying()
    {
        if (playerLife > 1)
        {
            FindObjectOfType<ButtonControl>().playAgain();
            //Life();
        }
        else
        {
            //PlayerMove.mAnimation.SetBool("isIdling", false);
            //PlayerMove.mAnimation.SetTrigger("isDying");
            FindObjectOfType<ButtonControl>().endGame();
        }
    }
    public void Life()
    {
        playerLife -= 1;
        liveText.text = playerLife.ToString();
        int sceneCurrent = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneCurrent);
        PlayerMove.Idle();
        //PlayerMove.mAnimation.SetTrigger(1);
            //FindObjectOfType<PlayerMove>().transform.position = PlayerMove.lastCheckPoint;
        GameObject.FindWithTag("Player").transform.position = PlayerManager.lastCheckPoint;
        
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
