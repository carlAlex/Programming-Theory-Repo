using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class ChickenBehaviour : AnimalBehaviour
{
    //POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("(Chicken sound..)! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Chicken: Collided with: " + collision.gameObject.name);
        Debug.Log("Chicken: Base class, what do you say?");
        base.ReactToCollision(collision);
    }
}
