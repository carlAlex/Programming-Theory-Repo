using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE
public class PenguinBehaviour : AnimalBehaviour
{

    //POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("(Penguin sound..)! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Penguin: Collided with: " + collision.gameObject.name);
    }
}
