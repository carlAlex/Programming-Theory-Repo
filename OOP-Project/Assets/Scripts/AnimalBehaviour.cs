using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE - Abstract BaseClass for type of behaviour
public abstract class AnimalBehaviour : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject target;

    protected Animator animalAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animalAnimator = GetComponent<Animator>();
        animalAnimator.SetInteger("Walk", 1);
        //target = GameObject.Find("Flower");
        SetTargetFlower();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            SetTargetFlower();
        }
        else
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    //ABSTRACTION
    private void SetTargetFlower()
    {
        GameObject[] flowerArray = GameObject.FindGameObjectsWithTag("Flower");
        target = flowerArray[Random.Range(0, flowerArray.Length)];
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReactToCollision(collision);
        if (collision.gameObject.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.NumberFlowers--;
            SetTargetFlower();
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
