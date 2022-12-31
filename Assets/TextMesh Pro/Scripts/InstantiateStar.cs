using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstantiateStar : MonoBehaviour
{
    public TextMeshProUGUI text;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    void Start()
    {
        EndGame();
    }

    void EndGame()
    {
        Vector3 star1Vec = new Vector3(-157, 80, 0);
        Vector3 star2Vec = new Vector3(12, 80, 0);
        Vector3 star3Vec = new Vector3(177, 80, 0);

        if (PlayerPrefs.GetInt("Score") >= 500)
        {
            GameObject newStar1 = Instantiate(star1, star1Vec, Quaternion.identity) as GameObject;           
            newStar1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            GameObject newStar2 = Instantiate(star2, star2Vec, Quaternion.identity) as GameObject;
            newStar2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            GameObject newStar3 = Instantiate(star3, star3Vec, Quaternion.identity) as GameObject;
            newStar3.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
        else if (PlayerPrefs.GetInt("Score") >= 400)
        {
            GameObject newStar1 = Instantiate(star1, star1Vec, Quaternion.identity) as GameObject;
            newStar1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            GameObject newStar2 = Instantiate(star2, star2Vec, Quaternion.identity) as GameObject;
            newStar2.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }
        else
        {
            GameObject newStar1 = Instantiate(star1, star1Vec, Quaternion.identity) as GameObject;              
            newStar1.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        }

        text.text = "" + PlayerPrefs.GetInt("Score");
        
    }
}
