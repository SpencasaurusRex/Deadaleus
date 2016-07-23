using UnityEngine;
using System.Collections;

public class Attractor : MonoBehaviour {

    private Gravity g;
    private Rigidbody2D rb;

	void Start () {
        g = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gravity>();
        rb = GetComponent<Rigidbody2D>();
        g.AddBody(rb);
    }

    void OnDestroy() {
        g.RemoveBody(rb);
    }
}
