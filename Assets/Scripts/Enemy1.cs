using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject enemyFx;
    static AudioSource audio;
    public GameObject bangEnemy;
    public GameObject enemyDmg;
    public float health = 10;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(CreateEnemyFx());
    }
    void Update()
    {
       
    }
    public void Death()
    {
        if (health==0)
        {
            Destroy(gameObject);
            var _instantiatedObj = Instantiate(bangEnemy, transform.position, Quaternion.identity);
            Destroy(_instantiatedObj,2f);
            GameController.instance.ScoreUp(GameController.EnemyTypes.enemy);
        }

    }
    public void DeathImmediately()
    {
        var _instantiatedObj = Instantiate(bangEnemy, transform.position, Quaternion.identity);
        Destroy(_instantiatedObj, 2f);
    }

    public void Damage()
    {
        var _instantiatedObj = Instantiate(enemyDmg, transform.position, Quaternion.identity);
        Destroy(_instantiatedObj, 1f);
    }

    IEnumerator CreateEnemyFx()
    {
        for (int i = 0; i < 45; i++)
        {        
           var _instantiatedObj = Instantiate(enemyFx, transform.position, Quaternion.identity);
            audio.Play();
            Destroy(_instantiatedObj, 3f);
            yield return new WaitForSeconds(1f);
        }
       
    }
}


