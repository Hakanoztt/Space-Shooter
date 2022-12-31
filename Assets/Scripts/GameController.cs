using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    AudioSource audio;

    public GameObject asteroid;
    public GameObject enemy;
    public GameObject enemy2;

    public Vector3 randomPos;
    public float startingAsteroidTime;
    public float asteroidTime;
    public float hardAsteroidTime;

    public int score = 0;
    public TextMeshProUGUI text;

    Coroutine routine = null;

    private GameObject _instantiatedEnemy1;
    public enum EnemyTypes { asteroid, enemy, enemy2 };
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }

    }
    public void SetInt(string KeyName, int score)
    {
        PlayerPrefs.SetInt(KeyName, score);
    }
    void Start()
    {

        audio = GetComponent<AudioSource>();
        routine = StartCoroutine(AsteroidandEnemy());
        PlayerPrefs.SetInt("Score", score);
    }
    public void ScoreUp(EnemyTypes type)
    {

        switch (type)
        {
            case EnemyTypes.asteroid:
                score += 10;
                break;

            case EnemyTypes.enemy:
                score += 50;
                break;

            case EnemyTypes.enemy2:
                score += 100;
                break;

            default:
                break;
        }
        text.text = "Score = " + score;
        PlayerPrefs.SetInt("Score", score);
    }
    public void Win()
    {
        score = 0;
        audio.enabled = false;
        StopCoroutine(routine);
    }
    public void Lose()
    {
        score = 0;
        audio.enabled = false;
        StopCoroutine(routine);
    }
    IEnumerator AsteroidandEnemy()
    {
        int x = 0;
        yield return new WaitForSeconds(startingAsteroidTime);

        while (x < 3)
        {
            if (x != 3)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector3 vec = new Vector3(UnityEngine.Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                    var _instantiatedObj = Instantiate(asteroid, vec, Quaternion.identity);
                    Destroy(_instantiatedObj, 6f);
                    yield return new WaitForSeconds(asteroidTime);
                }
            }

            if (x==1)
            {
                for (int j = 0; j < 3; j++)
                {
                    Vector3 vec = new Vector3(UnityEngine.Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                    var _instantiatedObj = Instantiate(asteroid, vec, Quaternion.identity);
                    Destroy(_instantiatedObj, 6f);
                    yield return new WaitForSeconds(asteroidTime);
                }
            }

            if (x == 2)
            {
                for (int j = 0; j < 20; j++)
                {
                    Vector3 vec = new Vector3(UnityEngine.Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                    var _instantiatedObj = Instantiate(asteroid, vec, Quaternion.identity);
                    Destroy(_instantiatedObj, 6f);
                    yield return new WaitForSeconds(hardAsteroidTime);
                }
            }

            yield return new WaitForSeconds(3f);

            if (x == 0)
            {
                Vector3 enemy1Vector = new Vector3(0, 0, 13.7f);
                _instantiatedEnemy1 = Instantiate(enemy, enemy1Vector, Quaternion.Euler(180, 0, 0));
                yield return new WaitForSeconds(1f);
            }
            else if (x == 1)
            {
                yield return new WaitUntil(() => _instantiatedEnemy1 == null);

                yield return new WaitForSeconds(2f);
                Vector3 enemy2Vector = new Vector3(0, 0, 13.7f);
                Instantiate(enemy2, enemy2Vector, Quaternion.Euler(180, 0, 0));
            }
            x++;
        }

    }
}