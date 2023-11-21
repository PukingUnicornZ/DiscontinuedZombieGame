using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwap : MonoBehaviour {
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject Assault;
    public GameObject sniper;
    public string currentGun;
    public static int gunNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(gunNumber == 0)
        {
            pistol.SetActive(true);
            Assault.SetActive(false);
            shotgun.SetActive(false);
            sniper.SetActive(false);
            currentGun = "pistol";
        }
        if (gunNumber == 1)
        {
            Assault.SetActive(true);
            pistol.SetActive(false);
            shotgun.SetActive(false);
            sniper.SetActive(false);
            currentGun = "assault rifle";
        }
        if (gunNumber == 2)
        {
            shotgun.SetActive(true);
            Assault.SetActive(false);
            pistol.SetActive(false);
            sniper.SetActive(false);
            currentGun = "shotgun";
        }
        if (gunNumber == 3)
        {
            sniper.SetActive(true);
            Assault.SetActive(false);
            shotgun.SetActive(false);
            pistol.SetActive(false);
            currentGun = "sniper";
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f&& gunNumber <= 2)
        {
            gunNumber++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f&& gunNumber >= 1)
        {
            gunNumber--;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "capturepoint")
        {
            AreaCapture.capture = true;

        }
        if (collision.gameObject.tag == "Floor")
        {
            AreaCapture.capture = false;

        }
    }
}
