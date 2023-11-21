using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAi : MonoBehaviour {
    //public GameObject player;
    public GameObject obj;
    public Transform tr_Player;
    public float f_RotSpeed;
    public float f_MoveSpeed;
    public float Closerange;
    public float Maxrange;
    // Use this for initialization
    void Start () {

       obj = GameObject.FindGameObjectWithTag("Player");
}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(transform.position, obj.transform.position) < Maxrange && Vector3.Distance(transform.position, obj.transform.position) > Closerange)
        {
            tr_Player = GameObject.FindGameObjectWithTag("Player").transform;

            /* Look at Player*/
            transform.rotation = Quaternion.Slerp(transform.rotation
                                                  , Quaternion.LookRotation(tr_Player.position - transform.position)
                                                  , f_RotSpeed * Time.deltaTime);

            /* Move at Player*/
            transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;



        }
    }
}

