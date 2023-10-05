using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D mRigidEnemy;
    [SerializeField] float speedEnemy = 2f;
    BoxCollider2D colliderWall;
    private void Start()
    {
        mRigidEnemy = GetComponent<Rigidbody2D>();
        colliderWall = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        mRigidEnemy.velocity = new Vector2(speedEnemy, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            speedEnemy = -speedEnemy;
            transform.localScale = new Vector2(-(Mathf.Sign(mRigidEnemy.velocity.x)), 1f);

        }
    }

}
