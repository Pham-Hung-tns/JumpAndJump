using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoins : MonoBehaviour
{
    [SerializeField] AudioClip soundPickup;
    [SerializeField] int amountPoint;
    bool wasCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            AudioSource.PlayClipAtPoint(soundPickup, collision.gameObject.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
            FindObjectOfType<Session>().AddScore(amountPoint);
            print(amountPoint);
        }
    }
}
