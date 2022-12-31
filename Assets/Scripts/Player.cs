using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public PlayerMovementModule movementModule;

    public GameObject bangPlayer;
    public GameObject lazer;
    public Transform lazerPosition;

    public MeshRenderer playerRenderer;
    public Collider playerCollider;
    public GameObject playerEffect;

    public TextMeshProUGUI textCharging;
    public TextMeshProUGUI textGunMagazine;

    public GameObject chargingFollow;
    public GameObject magazineFollow;

    AudioSource audio;

    public float fireDelay;
    public float destroyLazerTime;
    public float gunMagazine = 20f;
    public bool canReload;

    private float _fireTime = 0;
    private Vector3 _input;

    private GameObject _instantiatedObj;
    void Start()
    {
        audio = GetComponent<AudioSource>();

    }
    void Update()
    {
        GetInput();
        movementModule.Move();

        Vector3 chargingPos = Camera.main.WorldToScreenPoint(chargingFollow.transform.position);        
        textCharging.transform.position = chargingPos;

        Vector3 magazinePos = Camera.main.WorldToScreenPoint(magazineFollow.transform.position);
        textGunMagazine.transform.position = magazinePos; 
    }
    void GetInput()
    {
        textGunMagazine.text = "" + gunMagazine;
    }
    public void Reload()
    {
        if (gunMagazine < 15 && canReload == true)
        {
            gunMagazine = 0;
            StartCoroutine(ChargeGunForReload());
        }
    }
    public void Shooting()
    {
        if (Time.time > _fireTime && gunMagazine > 0 && playerRenderer.enabled == true)
        {
            _fireTime = Time.time + fireDelay;
            _instantiatedObj = Instantiate(lazer, lazerPosition.position, Quaternion.identity);
            Destroy(_instantiatedObj, destroyLazerTime);
            audio.Play();
            StartCoroutine(ChargeGun());
        }
    }
    IEnumerator ChargeGun()
    {
        gunMagazine--;
     
        if (gunMagazine == 0)
        {
            canReload = false;
            textGunMagazine.enabled = false;
            textCharging.enabled = true;
            textCharging.text = "Charging...";
            yield return new WaitForSeconds(2f);
            gunMagazine = 20f;
            textCharging.enabled = false;
            if (playerCollider.enabled ==true)
            {
                textGunMagazine.enabled = true;
            }
         
            canReload = true;
        }
    }
    IEnumerator ChargeGunForReload()
    {
        canReload = false;
        textGunMagazine.enabled = false;
        textCharging.enabled = true;
        textCharging.text = "Reloading...";
        yield return new WaitForSeconds(2f);
        gunMagazine = 20f;
        textCharging.enabled = false;
        textGunMagazine.enabled = true;
        canReload = true;
    }
    IEnumerator LoserScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Loser Scene");
        GameController.instance.Lose();
    }
    public void Death()
    {
        playerCollider.enabled = false;
        playerRenderer.enabled = false;
        Destroy(playerEffect);
        _instantiatedObj = Instantiate(bangPlayer, transform.position, Quaternion.identity);
        Destroy(_instantiatedObj, 1f);
        textCharging.enabled = false;
        textGunMagazine.enabled = false;
        canReload = false;
        StartCoroutine(LoserScene());
    }
}

[System.Serializable]
public class PlayerMovementModule
{
    public float rotateSpeed;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public Rigidbody rigidbody;

    public void Move()
    {

        rigidbody.position = new Vector3(Mathf.Clamp(rigidbody.position.x, minX, maxX),    // Rigidbody positionunun gideceği x ve z değerlerine sınır koyduk.
                                         0f,
                                         Mathf.Clamp(rigidbody.position.z, minZ, maxZ));

        rigidbody.rotation = Quaternion.Euler(0, 0, rigidbody.velocity.x * -rotateSpeed);    // Rigidbodymiz x ekseninde hareket ettiği zaman z rotate edecek.
    }
}
