using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Fun : MonoBehaviour {
    public float health;
    public static float maxhealth;
    public Slider healthbar;

    public float damage = 10f;
    public float range = 100f;
    public float firerate = 15f;
    public bool fire;
    public float spreadFactor = 0.1f;
    public float reloadtime;
    public bool reloadingB;
    //ammos
    public float time;
    public Text timerT;

    public float ammo1;
    public float ammo2;
    public float ammo3;
    public float ammo4;
    float maxammo1 = 10;
    float maxammo2 = 30;
    float maxammo3 = 5;
    float maxammo4 = 5;

    public bool sniperscoping;
    public GameObject sniperimg;


    public Text ammo;
    public string ammoStuff;
    public float currentammo;
    bool shotgunshot;
    public GameObject cam;
    public Camera Mcam;
    public Animation shooting;
    //models
    
    public GameObject gun;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    
    //muzzleflashes
    public ParticleSystem muzzleflash;
    public ParticleSystem muzzleflash1;
    public ParticleSystem muzzleflash2;
    public ParticleSystem shotgunflash;
    public int whatdamage;
    //Bools voor het bepalen welk wapen je hebt
    public bool pistol;
    public bool shotgun;
    public bool assault;
    public bool sniper;
    //Fire rates
    public float pistolfirerate;
    public float assaultfirerate;
    public float sniperfirerate;
    public float shotgunfirerate;
    int times = 8;
    private float nextTimeToFire = 0f;
    public GameObject scopecam;
    public GameObject crosshair;
    public GameObject snipecrosshair;
    public GameObject snipermodel2;
    bool snipingbool;
    public float sniperzoom;
    public int fix;
    public static bool fpsbool;
    public RawImage fadeimage;
    public RawImage fadeimage2;
    //public GameObject Target;
    // Use this for initialization
    void Start () {
        ammo1 = 10;
        ammo2 = 30;
        ammo3 = 5;
        ammo4 = 5;
        fire = true;
        health = maxhealth;
        fadeimage.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        timerT.text = "Time:" + time;
        fadeimage2.CrossFadeAlpha(0.0f, 5.0f, true);
        healthbar.value = health;
        healthbar.maxValue = maxhealth;
        if (health <= 0)
        {
            SceneManager.LoadScene("End");
            print("DEATHDEATHDEATH");
        }
        if(time <= 0)
        {
            SceneManager.LoadScene("End");
        }
        if (Input.GetKey(KeyCode.Mouse1)&& sniper == true)
        {
            if (snipingbool == true)
            {
                gun3.GetComponent<Animation>().Play("Snipperscoping");
                snipingbool = false;
            }
            StartCoroutine("Scoping");
            fpsbool = true;
                
            //cam.transform.position = new Vector3(cam.transform.position.x + 6, cam.transform.position.y, cam.transform.position.z);
        }
        else
        {
            sniperscoping = false;
            //cam.SetActive(true);
            //scopecam.SetActive(false);
            crosshair.SetActive(true);
        }
        if(sniperscoping == true)
        {
            sniper = false;
            Mcam.fieldOfView = sniperzoom;
            crosshair.SetActive(true);
            snipecrosshair.SetActive(true);
            snipermodel2.SetActive(false);
        }
        else
        {
            sniper = true;
            snipecrosshair.SetActive(false);
            Mcam.fieldOfView = 60;
            snipingbool = true;
            if(sniper == true)
            {
                //snipermodel2.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("reloading");
            reloadingB = true;
        }
        ammo.text = ammoStuff;
        whatdamage = GunSwap.gunNumber;
        if (whatdamage == 0)
        {
            ammoStuff = "" + ammo1 +"/"+ maxammo1;
            currentammo = ammo1;
            pistol = true;
            shotgun = false;
            assault = false;
            sniper = false;
            damage = 30;
            firerate = pistolfirerate;

        }
        if (whatdamage == 1)
        {
            currentammo = ammo2;
            ammoStuff = "" + ammo2 + "/" + maxammo2;
            pistol = false;
            shotgun = false;
            assault = true;
            sniper = false;
            damage = 100;
            firerate = assaultfirerate;

        }
        if (whatdamage == 2)
        {
            currentammo = ammo3;
            ammoStuff = "" + ammo3 + "/" + maxammo3;
            pistol = false;
            shotgun = true;
            assault = false;
            sniper = false;
            damage = 20;
            firerate = shotgunfirerate;
        }
        if (whatdamage == 3)
        {
            currentammo = ammo4;
            ammoStuff = "" + ammo4 + "/" + maxammo4;
            pistol = false;
            shotgun = false;
            assault = false;
            sniper = true;
            damage = 100;
            firerate = sniperfirerate;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire&& assault != true&& shotgun != true && reloadingB == false)
        {
            nextTimeToFire = Time.time + 1f / firerate;
            Shoot();
            if (pistol == true&& currentammo > 0)
            {
                gun.GetComponent<Animation>().Play("Shoot");
                ammo1--;
            }

            if (sniper == true&& currentammo > 0)
            {
                print("SNIPPERED");
                gun3.GetComponent<Animation>().Play("Snipper");
                ammo4--;
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire&& assault == true&& fire == true && reloadingB == false)
        {
            Shoot();
            if (assault == true&& currentammo > 0)
            {
                gun1.GetComponent<Animation>().Play("assault");
                ammo2--;
            }
            fire = false;
            StartCoroutine("assaultwait");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire && shotgun == true && reloadingB == false)
        {
            //print("shotgun");

            if (shotgun == true && currentammo > 0)
            {
                //gun.GetComponent<Animation>().Play("Shoot");
                ammo3--;
                nextTimeToFire = Time.time + 1f / firerate;
                shotgunflash.Play();
                //shotgunshot = true;
                ShootSHOTGUN();
                ShootSHOTGUN();
                ShootSHOTGUN();
                ShootSHOTGUN();
                ShootSHOTGUN();
                ShootSHOTGUN();
                ShootSHOTGUN();
            }
        }
        
    }
    IEnumerator assaultwait()
    {

        yield return new WaitForSeconds(0.1f);
        StopCoroutine("assaultwait");
        fire = true;
    }
    IEnumerator Scoping()
    {

        yield return new WaitForSeconds(0.7f);
        StopCoroutine("Scoping");
        sniperscoping = true; 
    }
    IEnumerator reloading()
    {
        if (whatdamage == 0)
        {
            gun.GetComponent<Animation>().Play("Pm-40reload");
        }
        if(whatdamage == 1)
        {
            gun1.GetComponent<Animation>().Play("assaultreload");
        }
        if (whatdamage == 3)
        {
            gun1.GetComponent<Animation>().Play("Sniperreload");
        }
        yield return new WaitForSeconds(reloadtime);
        StopCoroutine("reloading");
        reload();
        reloadingB = false;

    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemie")
        {
            health -= 10;
            fadeimage.canvasRenderer.SetAlpha(1.0f);
            fadeimage.CrossFadeAlpha(0.0f, 1.0f, true);
        }
    }
    void reload()
    {
        if(whatdamage == 0)
        {
            ammo1 = maxammo1;
        }
        if (whatdamage == 1)
        {
            ammo2 = maxammo2;
        }
        if (whatdamage == 2)
        {
            ammo3 = maxammo3;
        }
        if (whatdamage == 3)
        {
            ammo4 = maxammo4;
        }
    }
    void Shoot()
    {
        if (currentammo > 0)
        {
            if (whatdamage == 3) muzzleflash.Play();
            if (whatdamage == 0) muzzleflash1.Play();
            if (whatdamage == 1) muzzleflash2.Play();
        }

        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green, 4);
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            

            Damge target = hit.transform.GetComponent<Damge>();
            if (target != null&& currentammo > 0)
            {
                target.GotHit(damage);

            }
        }
    }
    void ShootSHOTGUN()
    {
        Vector3 fwd = cam.transform.forward;
        fwd.x += Random.Range(-spreadFactor, spreadFactor);
        fwd.y += Random.Range(-spreadFactor, spreadFactor);
        fwd.z += Random.Range(-spreadFactor, spreadFactor);
        RaycastHit hit = new RaycastHit();
        Vector3 forward = fwd * 10;
        Debug.DrawRay(transform.position, forward, Color.red, 4);
        if (Physics.Raycast(cam.transform.position, forward, out hit)){

            Damge target = hit.transform.GetComponent<Damge>();
            if (target != null)
            {
                target.GotHit(damage);
            }
        }



        //Debug.Log(hit.transform.name);






    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        time--;
        StartCoroutine("Timer");

    }
}
