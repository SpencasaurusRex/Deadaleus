using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float range = 5;
    public float damage = 100;
    public float speed = 10;
    public Vector3 direction = new Vector3();
    public GameObject creator;

    private float distanceTravelled = 0;
    private Transform tf;
    private SpriteRenderer sr;
    public Vector2 velocity;
    public float currentDamage;
    public float strength;
    public float linearStrength;

	void Start () {
        tf = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        //Update position
        tf.position += new Vector3(velocity.x, velocity.y, 0.01f) * Time.deltaTime + direction * speed * Time.deltaTime;

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
                otherUnit.damage(currentDamage);
                Debug.Log(currentDamage);
                Destroy(gameObject);
            }
        }
    }
}