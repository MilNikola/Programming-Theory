using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject Enemy1;
    [SerializeField] private GameObject Enemy2;
    [SerializeField] private GameObject Enemy3;
    [SerializeField] private float spawnRate;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        if (!gameManager.isGameOver)
        {
            switch (Random.Range(1, 6))
            {
                case 1: Instantiate(Enemy2, new Vector3(Random.Range(-6f, 6f), 35, -1), Enemy2.transform.rotation); break;
                case 2: Instantiate(Enemy3, new Vector3(Random.Range(-6f, 6f), 35, -1), Enemy3.transform.rotation); break;
                default: Instantiate(Enemy1, new Vector3(Random.Range(-6f, 6f), 35, -1), Enemy1.transform.rotation); break;
            }
        }
    }

    private IEnumerator SpawnTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }

}
