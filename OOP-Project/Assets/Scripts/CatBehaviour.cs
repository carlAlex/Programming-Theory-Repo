using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaviour : AnimalBehaviour
{
    protected override void Speak()
    {
        Debug.Log("Meow! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Cat: Collided with: " + collision.gameObject.name);
        Debug.Log("Cat: Base class, what do you say?");
        base.ReactToCollision(collision);
    }
}
