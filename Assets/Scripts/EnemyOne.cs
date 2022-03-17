using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : SpaceShip
{
    [SerializeField] private GameObject center;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireRate());
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
        MoveDown();
    }

    IEnumerator FireRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            Shoot();
        }
    }

    protected override void Shoot()
    {
        Instantiate(bullet, center.transform.position, bullet.transform.rotation);
    }
}
