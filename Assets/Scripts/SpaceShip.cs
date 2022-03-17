using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceShip : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float fireRate;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    protected void MoveDown()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    protected abstract void Shoot();
    protected void OutOfBounds()
    {
        if (transform.position.y <= 20f)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
