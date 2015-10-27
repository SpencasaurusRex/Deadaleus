using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public float maxHealth;
    private float health;

    public Unit()
    {
        
    }

	void Start () {
        health = maxHealth;
	}
	
	void Update () {
	
	}

    public void damage(float amount)
    {
        if (amount > 0)
        {
            health -= amount;
        }
        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        Destroy(gameObject);
    }
}