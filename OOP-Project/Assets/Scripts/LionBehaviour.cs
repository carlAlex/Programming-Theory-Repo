using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class LionBehaviour : AnimalBehaviour
{
    //POLYMORPHISM
    protected override void Speak()
    {
        Debug.Log("Roar! I found a flower..");
    }

    protected override void ReactToCollision(Collision collision)
    {
        Debug.Log("Lion: Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Flower"))
        {
            //Because I believe lions jump when they eat flowers(?)
            base.animalAnimator.SetTrigger("jump");
            base.animalRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}
