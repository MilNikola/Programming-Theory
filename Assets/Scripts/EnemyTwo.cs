using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : SpaceShip
{
    // Start is called before the first frame update
    void Start()
    {
        speed += (speed / 2);
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
        MoveDown();
    }
    protected override void Shoot()
    {
    }
}
