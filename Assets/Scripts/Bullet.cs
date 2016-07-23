using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float range = 5;
    public float damage = 100;
    public float speed = 10;
    public GameObject creator;

    private float distanceTravelled = 0;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    public float currentDamage;
    public float strength;
    public float linearStrength;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(float force)
    {
        rb.AddRelativeForce(new Vector2(0, force));
    }

    void Update()
    {
        //Calculate distance travelled
        distanceTravelled += speed * Time.deltaTime;

        //Calculate lifetime
        if (distanceTravelled >= range)
        {
            Destroy(this.gameObject);
        }

        linearStrength = (range - distanceTravelled) / range;
        strength = Mathf.Sqrt(2 * linearStrength) / Mathf.Sqrt(2);

        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, strength);
        currentDamage = damage * strength;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Unit otherUnit = other.gameObject.GetComponent<Unit>();
        if (otherUnit != null)
        {
            if (other.gameObject != creator)
            {
                otherUnit.damage(new Damage(currentDamage));
                Destroy(gameObject);
            }
        }
    }
}