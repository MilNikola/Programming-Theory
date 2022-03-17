using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        OutOfBounds();
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    protected void OutOfBounds()
    {
        if (transform.position.y <= 20f)
        {
            Destroy(gameObject);
        }
    }
}
