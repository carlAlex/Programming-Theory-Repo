using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//INHERITANCE - Abstract BaseClass for type of behaviour
public abstract class AnimalBehaviour : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject targetGameObj;

    //Protected so Lion can do some different stuff
    protected Animator animalAnimator;
    protected Rigidbody animalRb;

    public NavMeshAgent agent;

    //Find food
    private float spawnX = 250f;
    private float spawnZ = 250f;
    private float spawnRange = 40.0f;
    [SerializeField]
    private bool searchMode = false;
    private IFoodFinder foodFinder;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        animalAnimator = GetComponent<Animator>();
        animalAnimator.SetInteger("Walk", 1);
        agent = GetComponent<NavMeshAgent>();
        //LookForTarget();
        switch (gameObject.name)
        {
            case "Chicken":
                foodFinder = new ChickenSensors();
                break;
            case "Penguin":
                foodFinder = new PenguinSensors();
                break;
            case "Lion":
                foodFinder = new LionSensors();
                break;
            case "Dog":
                foodFinder = new DogSensors();
                break;
            case "Cat":
                foodFinder = new CatSensors();
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (targetGameObj == null || AgentReachedTarget())
        {
            Transform target = FindTarget();
            //A target has to be withing the animals "sensors" to be noticed
            if (target != null)
            {
                SetTargetFlower(target);
            }
            else
            {
                //No visible flowers!
                if (!agent.hasPath && !agent.pathPending)
                {
                    Debug.Log(gameObject.name + " setting random destination..");
                    SetRandomDestinationToSearch();
                }
            }
        }
    }

    private bool AgentReachedTarget()
    {
        //Is a path in the process of being computed but not yet ready?
        if (!agent.pathPending)
        {
            //The distance between the agent's position and the destination on the current path.
            //Stop within this distance from the target position.
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                //Does the agent currently have a path?
                //..current velocity of the NavMeshAgent..
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    return true;
                }
                else { return false; }
            }
            else
            {
                //Agent is navigating with "long" remainingDistance
                return false;
            }
        }
        else
        {
            //Agent has pathPending, lets wait for that..
            return false;
        }
    }

    private Transform FindTarget()
    {
        GameObject[] flowerArray = GameObject.FindGameObjectsWithTag("Flower");
        int targetFlower = 0;
        bool targetFound = false;

        FindVisibleFlower(flowerArray, ref targetFlower, ref targetFound);

        if (targetFound)
        {
            targetGameObj = flowerArray[targetFlower];
            return flowerArray[targetFlower].transform;
        }
        else
        {
            return null;
        }
    }

    private void SetRandomDestinationToSearch()
    {
        Vector3 searchPos = new Vector3(
                        Random.Range(spawnX - spawnRange, spawnX + spawnRange),
                        0,
                        Random.Range(spawnZ - spawnRange, spawnZ + spawnRange));
        agent.SetDestination(searchPos);
    }

    private void FindVisibleFlower(GameObject[] flowerArray, ref int targetFlower, ref bool targetFound)
    {
        for (int i = 0; i < flowerArray.Length; i++)
        {
            Vector3 flower = flowerArray[i].transform.position;
            Vector3 targetDir = flower - transform.position;
            float angle = Vector3.Angle(targetDir, transform.forward);
            float dist = Vector3.Distance(flower, transform.position);
            //Make use of IFoodFinder interface
            if (foodFinder.ValidateParameters(angle, dist))
            {
                targetFlower = i;
                targetFound = true;
                //Debug.Log(gameObject.name + " found flower! Angle: " + angle + " Dist: " + dist);
            }
        }
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
            //LookForTarget();
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
