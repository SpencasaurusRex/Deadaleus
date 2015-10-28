using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{

    public float strength;
    public float strengthRemaining;
    public bool active;

    private Collider2D shieldCollider;

    void Start()
    {
        strengthRemaining = strength;
        shieldCollider = GetComponents<Collider2D>()[1];
    }

    void Update()
    {
        shieldCollider.enabled = active;
    }

    public void damage(Damage d)
    {
        if (active)
        {
            if (d.amount < strengthRemaining)
            {
                strengthRemaining -= d.amount;
                d.amount = 0;
            }
            else if (d.amount > strengthRemaining)
            {
                d.amount -= strengthRemaining;
                strengthRemaining = 0;
            }
            else
            {
                strengthRemaining = d.amount = 0;
            }
            if (strengthRemaining <= 0)
            {
                active = false;
            }
        }
    }
}