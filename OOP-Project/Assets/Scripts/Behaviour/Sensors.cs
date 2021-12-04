using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSensors : IFoodFinder
{
    bool IFoodFinder.ValidateParameters(float angle, float distance)
    {
        if (angle < 30 && distance < 20)
        {
            return true;
        }
        return false;
    }
}

public class PenguinSensors : IFoodFinder
{
    bool IFoodFinder.ValidateParameters(float angle, float distance)
    {
        if (angle < 30 && distance < 20)
        {
            return true;
        }
        return false;
    }
}

public class LionSensors : IFoodFinder
{
    bool IFoodFinder.ValidateParameters(float angle, float distance)
    {
        if (angle < 60 && distance < 50)
        {
            return true;
        }
        return false;
    }
}

public class DogSensors : IFoodFinder
{
    bool IFoodFinder.ValidateParameters(float angle, float distance)
    {
        if (angle < 30 && distance < 20)
        {
            return true;
        }
        return false;
    }
}

public class CatSensors : IFoodFinder
{
    bool IFoodFinder.ValidateParameters(float angle, float distance)
    {
        if (angle < 30 && distance < 20)
        {
            return true;
        }
        return false;
    }
}
