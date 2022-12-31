using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFx : MonoBehaviour
{
    public Rigidbody rigidbody;

    public float fxSpeed;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = -transform.forward * fxSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            var player = other.GetComponent<Player>();
            player.Death();
           
        }
    }
    void Update()
    {
         
    }
}
