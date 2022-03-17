using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : SpaceShip
{
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    // Start is called before the first frame update
    void Start()
    {
        fireRate += (fireRate / 2);
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
        Instantiate(bullet, left.transform.position, bullet.transform.rotation);
        Instantiate(bullet, right.transform.position, bullet.transform.rotation);
    }

}
