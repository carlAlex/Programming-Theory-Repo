using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE - Abstract BaseClass for type of behaviour
public abstract class AnimalBehaviour : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject target;

    protected Animator animalAnimator;
    protected Rigidbody animalRb;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        animalAnimator = GetComponent<Animator>();
        animalAnimator.SetInteger("Walk", 1);
        agent = GetComponent<NavMeshAgent>();
        SetTarget();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (target == null)
        {
            SetTarget();
        }
    }

    //ABSTRACTION
    protected virtual void SetTarget()
    {
        GameObject[] flowerArray = GameObject.FindGameObjectsWithTag("Flower");
        target = flowerArray[Random.Range(0, flowerArray.Length)];
        agent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReactToCollision(collision);
        if (collision.gameObject.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.NumberFlowers--;
            SetTarget();
        }
    }

    //POLYMORPHISM (preparation for children)
    //ABSTRACTION
    //Virtual method - Children should provide appropriate response depending on type
    protected virtual void ReactToCollision(Collision collision)
    {
        Debug.Log("AnimalBehaviour class - Collided with: " + collision.gameObject.name);
    }

    //Abstract so each child must implement appropriate behaviour
    protected abstract void Speak();
}
