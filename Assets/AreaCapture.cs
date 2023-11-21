using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaCapture : MonoBehaviour {
    public static bool capture;
    public float areahealth;
    public float areahealth2;
    public float capturepersecond;
    public float capturepower;
    public GameObject player;
    public Slider CapVis;
    public GameObject slider;
	// Use this for initialization
	void Start () {
        CapVis.maxValue = areahealth2;
        slider.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        CapVis.value = areahealth;
		if(capture == true)
        {
            slider.SetActive(true);
            StartCoroutine("CaptureTime");
        }
        if(capture == false)
        {
            slider.SetActive(false);
        }
        if(areahealth >= areahealth2)
        {
            print("WIN");
            LevelManager.LaadLevel3("Start");
        }
	}

    IEnumerator CaptureTime()
    {

        yield return new WaitForSeconds(capturepersecond);
        StopCoroutine("CaptureTime");
        areahealth = areahealth + capturepower;
    }
}
