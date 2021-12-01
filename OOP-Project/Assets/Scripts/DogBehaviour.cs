using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : AnimalBehaviour
{
    protected override void Speak()
    {
        Debug.Log("Woof! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Dog: Collided with: " + collision.gameObject.name);
        Debug.Log("Dog: Base class, what do you say?");
        base.ReactToCollision(collision);
    }
}
