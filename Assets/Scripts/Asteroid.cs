using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    Rigidbody rigidbody;
    public GameObject asteroidBang;

   

    public float rotateSpeed;
    public float speed;

    private GameObject _instantiatedObj;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * rotateSpeed;

        rigidbody.velocity = -transform.forward * speed;

    }

    public void Death()
    {
        var _instantiatedObj = Instantiate(asteroidBang, transform.position, Quaternion.identity);
        Destroy(_instantiatedObj, 2f);
        Destroy(gameObject);
        GameController.instance.ScoreUp(GameController.EnemyTypes.asteroid);
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
}
