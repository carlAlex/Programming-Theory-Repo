using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionBehaviour : AnimalBehaviour
{
    protected override void Speak()
    {
        Debug.Log("Roar! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Lion: Collided with: " + collision.gameObject.name);
        Debug.Log("Lion: Base class, what do you say?");
        base.ReactToCollision(collision);
    }
}
