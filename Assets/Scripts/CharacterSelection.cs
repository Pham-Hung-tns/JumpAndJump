using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] amountCharacter;
    public int selectedCharacter;
    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in amountCharacter)
        {
            player.SetActive(false);
        }
        amountCharacter[selectedCharacter].SetActive(true);
    }
    public void ChangNext()
    {
        amountCharacter[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == amountCharacter.Length)
        {
            selectedCharacter = 0;
        }
        amountCharacter[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
    public void ChangPrevious()
    {
        amountCharacter[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
        {
            selectedCharacter = amountCharacter.Length - 1;
        }
        amountCharacter[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
    }
}
