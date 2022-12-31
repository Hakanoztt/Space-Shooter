using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
    Rigidbody rigidbody;
    public float fxSpeed;
    

    private GameObject _instantiatedObj;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * fxSpeed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            var asteroid = other.GetComponent<Asteroid>();
            asteroid.Death();
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            var enemy1 = other.GetComponent<Enemy1>();
            enemy1.health--;
            enemy1.Damage();
            enemy1.Death();
          
        }

        if(other.CompareTag("Enemy2"))
        {
            Destroy(gameObject);
            var enemy2 = other.GetComponent<Enemy2>();
            enemy2.health--;
            enemy2.Damage();
            enemy2.Death();
            
        }


    }

}
