using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damge : MonoBehaviour {

    public float health;
	// Use this for initialization
    public void GotHit(float damage2)
    {
        health -= damage2;
        if(health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
