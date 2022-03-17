using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameManager gameManager;
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        OutOfBounds();
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyOne>() != null)
            {
                gameManager.AddPoints(1);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (other.gameObject.GetComponent<EnemyTwo>() != null)
            {
                gameManager.AddPoints(2);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            else if (other.gameObject.GetComponent<EnemyThree>() != null)
            {
                gameManager.AddPoints(3);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
    protected void OutOfBounds()
    {
        if (transform.position.y >= 35f)
        {
            Destroy(gameObject);
        }
    }
}
