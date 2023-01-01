using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour
{
    public GameObject enemyFx;
    public GameObject bangEnemy;
    public GameObject enemyDmg;
    public GameObject enemyLazerPosition;
    public GameObject enemyEffect;
    AudioSource audio;

    public MeshRenderer enemy2Renderer;
   public Collider enemy2Collider;

    public float speed;


    public bool moveRight=true;

    public float health = 25;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(CreateEnemyFx());
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (moveRight)
        {
            transform.Translate(2 * speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-2 * speed * Time.deltaTime, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovePoint2"))
        {
            moveRight = false;
        }   
        if (other.CompareTag("MovePoint1"))
        {
            moveRight = true;
        }
    }
    public void Damage()
    {
        var _instantiatedObj = Instantiate(enemyDmg, transform.position, Quaternion.identity);
        Destroy(_instantiatedObj, 1f);
    }
    public void Death()
    {
        if (health == 0)
        {
            audio.enabled = false;
            enemy2Renderer.enabled = false;
            enemy2Collider.enabled = false;
            Destroy(enemyEffect);
            var _instantiatedObj = Instantiate(bangEnemy, transform.position, Quaternion.identity);
            Destroy(_instantiatedObj, 2f);
            GameController.instance.ScoreUp(GameController.EnemyTypes.enemy2);
            StartCoroutine(WinningScene());
        }
    }
    IEnumerator WinningScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Winning Scene");
        GameController.instance.Win();
    }

    IEnumerator CreateEnemyFx()
    {
        if (enemy2Renderer.enabled == true)
        {
            for (int i = 0; i < 500; i++)
            {
                Instantiate(enemyFx, enemyLazerPosition.transform.position, Quaternion.identity);
                audio.Play();
                if (i < 3)
                {
                    yield return new WaitForSeconds(1.5f);
                }
                else if (i<8)
                {
                    yield return new WaitForSeconds(1f);
                }
                else
                {
                    yield return new WaitForSeconds(0.5f);
                }

            }
        }

    }

}
