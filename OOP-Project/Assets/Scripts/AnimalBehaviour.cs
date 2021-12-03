using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE - Abstract BaseClass for type of behaviour
public abstract class AnimalBehaviour : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject target;

    //Protected so Lion can do some different stuff
    protected Animator animalAnimator;
    protected Rigidbody animalRb;

    private NavMeshAgent agent;

    //Find food
    private float spawnX = 250f;
    private float spawnZ = 250f;
    private float spawnRange = 40.0f;
    private bool searchMode = false;
    private IFoodFinder foodFinder = new ChickenSensors();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        animalAnimator = GetComponent<Animator>();
        animalAnimator.SetInteger("Walk", 1);
        agent = GetComponent<NavMeshAgent>();
        LookForTarget();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (target == null)
        {
            Transform target = LookForTarget();
            if (target != null)
            {
                SetTargetFlower(target);
            }
        }
    }

    //ABSTRACTION
    protected virtual Transform LookForTarget()
    {
        GameObject[] flowerArray = GameObject.FindGameObjectsWithTag("Flower");
        //target = flowerArray[Random.Range(0, flowerArray.Length)];
        //agent.SetDestination(target.transform.position);
        //float smallestAngle = 360f;
        int targetFlower = 0;
        bool targetFound = false;

        Debug.Log(gameObject.name + " looking for flower..");

        for (int i = 0; i < flowerArray.Length; i++)
        {
            Vector3 flower = flowerArray[i].transform.position;
            Vector3 targetDir = flower - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            if (angle < 30)
            {
                if (Vector3.Distance(flower, transform.position) < 20)
                {
                    targetFlower = i;
                    targetFound = true;
                    Debug.Log(gameObject.name + " found flower!");
                }
                //smallestAngle = angle;
            }
        }
        if (targetFound)
        {
            target = flowerArray[targetFlower];
            searchMode = false;
            return flowerArray[targetFlower].transform;
        }
        else
        {
            Debug.Log(gameObject.name + " could not find flower..");
            if (!searchMode)
            {
                Vector3 searchPos = new Vector3(
                Random.Range(spawnX - spawnRange, spawnX + spawnRange),
                0,
                Random.Range(spawnZ - spawnRange, spawnZ + spawnRange));
                agent.SetDestination(searchPos);
                searchMode = true;
                Debug.Log(gameObject.name + " setting new search point..");
            } else
            {
                if (Vector3.Distance(agent.destination, transform.position) < 0.5f)
                {
                    Debug.Log(gameObject.name + " nothing here..");
                    searchMode = false;
                }
            }
            
            return null;
        }
        
        //Debug.Log("SetDest - Angle: " + smallestAngle + " Flower: " + targetFlower);
        //SetTargetFlower(flowerArray, targetFlower, targetFound);

    }

    private void SetTargetFlower(Transform target)
    {
        agent.SetDestination(target.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReactToCollision(collision);
        if (collision.gameObject.CompareTag("Flower"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.NumberFlowers--;
            LookForTarget();
        }
    }

    //POLYMORPHISM (preparation for children)
    //ABSTRACTION
    //Virtual method - Children should provide appropriate response depending on type
    protected virtual void ReactToCollision(Collision collision)
    {
        //Debug.Log("AnimalBehaviour class - Collided with: " + collision.gameObject.name);
    }

    //Abstract so each child must implement appropriate behaviour
    protected abstract void Speak();
}
