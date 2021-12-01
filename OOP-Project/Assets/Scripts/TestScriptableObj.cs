using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Food")]
public class TestScriptableObj : ScriptableObject
{
    public string foodName;
    public int totalCalories;
    public bool needsCooking;
}
