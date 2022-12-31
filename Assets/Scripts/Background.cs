using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    Vector3 StartPosition;
    void Start()
    {
        Vector3 StartPosition = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.z < -29.90)
        {
            transform.position = StartPosition;
        }
    }
}
