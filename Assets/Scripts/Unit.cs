using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    public float maxHealth;
    public float health;
    public Shield shield;

    void Start()
    {
        shield = GetComponent<Shield>();
        health = maxHealth;
    }

    void Update()
    {

    }

    public void damage(Damage d)
    {
        // If damage is applicable
        if (d.amount > 0)
        {
            shield.damage(d);
            health -= d.amount;
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