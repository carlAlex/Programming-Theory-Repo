using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class CatBehaviour : AnimalBehaviour
{
    //POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("Meow! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Cat: Collided with: " + collision.gameObject.name);
    }
}
