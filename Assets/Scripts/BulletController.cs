using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D mbullet;
    [SerializeField] float speedBullet;
    PlayerMove Player;
    void Start()
    {
        mbullet = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<PlayerMove>();
        speedBullet = Player.transform.localScale.x * speedBullet;
    }

    // Update is called once per frame
    void Update()
    {

        mbullet.velocity = new Vector2(speedBullet, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
