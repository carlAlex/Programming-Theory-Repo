using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public GameObject target;

    private Animator animalAnimator;

    // Start is called before the first frame update
    void Start()
    {
        animalAnimator = GetComponent<Animator>();
        animalAnimator.SetInteger("Walk", 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
    }
}
