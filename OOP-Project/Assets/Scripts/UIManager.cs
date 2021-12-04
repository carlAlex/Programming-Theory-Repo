using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject animal = null;
    public Text gameObjText;
    public Text gameObjTarget;
    public Text hasPath;
    public Text pathPending;
    public Text remainDist;
    public Text velocity;
    public Text destination;
    public Text location;

    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Animal"))
                {
                    animal = hit.collider.gameObject;
                    Debug.Log("Raycast hit: " + hit.collider.name);
                }
                Debug.Log("Hit " + hit.collider.gameObject.name);
            }
        }

        if (animal != null)
        {
            AnimalBehaviour ab = animal.GetComponent<AnimalBehaviour>();
            gameObjText.text = "Animal: " + animal.name;
            if (ab.targetGameObj != null)
            {
                gameObjTarget.text = "Target: " + ab.targetGameObj.name;
            } else
            {
                gameObjTarget.text = "Target: Looking for target..";
            }
            hasPath.text = "HasPath: " + ab.agent.hasPath.ToString();
            pathPending.text = "PathPending: " + ab.agent.pathPending.ToString();
            remainDist.text = "RemDist: " + ab.agent.remainingDistance.ToString();
            velocity.text = "Velocity: " + ab.agent.velocity.sqrMagnitude.ToString();
            destination.text = "Destination: " + ab.agent.destination.ToString();
            location.text = "Location: " + animal.transform.position.ToString();
        }
        
    }
}
