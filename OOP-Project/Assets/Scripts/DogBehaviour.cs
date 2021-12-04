using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class DogBehaviour : AnimalBehaviour
{
    //POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("Woof! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        //Debug.Log("Dog: Collided with: " + collision.gameObject.name);
    }
}
