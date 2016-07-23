using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravity : MonoBehaviour {
    private List<Rigidbody2D> bodies = new List<Rigidbody2D>();
    private const double GRAVITATIONAL_CONSTANT = .0000000000667;
    private const double OUR_CONSTANT = GRAVITATIONAL_CONSTANT * 1000000;
	
	void Update () {
        foreach (Rigidbody2D bodyA in bodies)
        {
            foreach (Rigidbody2D bodyB in bodies)
            {
                if (bodyA != bodyB)
                {
                    Attract(bodyA, bodyB);
                }
            }
        }
	}

    private void Attract(Rigidbody2D a, Rigidbody2D b)
    {
        Vector2 aPos = a.worldCenterOfMass;
        Vector2 bPos = b.worldCenterOfMass;
        double deltaX = (aPos.x - bPos.x);
        double deltaY = (aPos.y - bPos.y);
        double distanceSquared = deltaX * deltaX + deltaY * deltaY;
        if (distanceSquared != 0)
        {
            double force = (OUR_CONSTANT * a.mass * b.mass) / distanceSquared;
            Attract(a, b, force);
        }
    }

    private void Attract(Rigidbody2D a, Rigidbody2D b, double magnitude)
    {
        Vector2 forceDirection = b.worldCenterOfMass - a.worldCenterOfMass;
        forceDirection.Normalize();
        Vector2 force = forceDirection * (float)magnitude;
        a.AddForce(force);
    }

    public void AddBody(Rigidbody2D body)
    {
        bodies.Add(body);
    }

    public void RemoveBody(Rigidbody2D body)
    {
        bodies.Remove(body);
    }
}
