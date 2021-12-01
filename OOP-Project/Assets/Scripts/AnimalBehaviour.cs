using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE - Abstract BaseClass for type of behaviour
public abstract class AnimalBehaviour : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject target;

    private Animator animalAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animalAnimator = GetComponent<Animator>();
        animalAnimator.SetInteger("Walk", 1);
        target = GameObject.Find("Flower");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReactToCollision(collision);
    }

    //POLYMORPHISM
    //Virtual method - Children should provide appropriate response depending on type
    protected virtual void ReactToCollision(Collision collision)
    {
        Debug.Log("AnimalBehaviour class - Collided with: " + collision.gameObject.name);
    }

    //Abstract so each child must implement appropriate behaviour
    protected abstract void Speak();
}
