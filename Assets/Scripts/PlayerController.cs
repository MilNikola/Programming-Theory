using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject center;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameOver)
        {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                Instantiate(bullet, center.transform.position, bullet.transform.rotation);
                }
           
            float horizontalInput = Input.GetAxis("Horizontal");
            gameObject.transform.Translate(Vector3.left * speed * horizontalInput * Time.deltaTime);
            if (gameObject.transform.position.x < -6)
            {
                gameObject.transform.position = new Vector3(-6, transform.position.y, transform.position.z);
            }
            if (gameObject.transform.position.x > 6)
            {
                gameObject.transform.position = new Vector3(6, transform.position.y, transform.position.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.GameOver();
        Destroy(gameObject);
    }
}
