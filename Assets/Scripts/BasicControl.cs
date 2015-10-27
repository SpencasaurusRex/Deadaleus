using UnityEngine;
using System.Collections;

public class BasicControl : MonoBehaviour {

    public float engineForce = 100;
    public Camera cam;
    public GameObject bullet;
    public float cooldown = .3f;

    private Rigidbody2D rb;
    private Transform tf;
    public float currentCooldown;
    private const float TORQUE_DAMPENER = .05f;
    private const float BACK_DAMPENER = 0.3f;
    private const float DISTANCE = .3f;

	void Start () {
	    rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        currentCooldown = cooldown;
    }
	
	void Update () {
        Vector2 force = new Vector2();
        float torque = 0;

        if (Input.GetKey(KeyCode.W))
        {
            force += new Vector2(engineForce, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            force -= new Vector2(engineForce, 0) * BACK_DAMPENER;
        }
        if (Input.GetKey(KeyCode.A))
        {
            torque += engineForce;
        }
        if (Input.GetKey(KeyCode.D))
        {
            torque -= engineForce;
        }

        rb.AddRelativeForce(force * Time.deltaTime);
        rb.AddTorque(torque * Time.deltaTime * TORQUE_DAMPENER);

        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0)
        {
            currentCooldown = 0;
        }

        if (Input.GetKey(KeyCode.Space) && currentCooldown <= 0)
        {
            currentCooldown += cooldown;
            GameObject b = Instantiate(bullet);
            Bullet bul = b.GetComponent<Bullet>();
            bul.velocity = rb.velocity;
            bul.direction = new Vector3(Mathf.Cos(tf.rotation.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(tf.rotation.eulerAngles.z * Mathf.Deg2Rad), 0);
            bul.creator = gameObject;
            Transform trans = b.GetComponent<Transform>();
            trans.position = tf.position + bul.direction * DISTANCE;
            trans.rotation = tf.rotation;
        }

        cam.transform.position = new Vector3(tf.position.x, tf.position.y, cam.transform.position.z);
    }
}