using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehaviour : AnimalBehaviour
{
    protected override void Speak()
    {
        Debug.Log("(Penguin sound..)! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Penguin: Collided with: " + collision.gameObject.name);
        Debug.Log("Penguin: Base class, what do you say?");
        base.ReactToCollision(collision);
    }
}
