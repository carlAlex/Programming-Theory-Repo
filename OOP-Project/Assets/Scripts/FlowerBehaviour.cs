using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehaviour : MonoBehaviour
{
    public TestScriptableObj foodConfig;
    private string foodName;
    private int totalCalories;
    private bool needsCooking;

    // Start is called before the first frame update
    void Start()
    {
        foodName = foodConfig.foodName;
        totalCalories = foodConfig.totalCalories;
        needsCooking = foodConfig.needsCooking;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
