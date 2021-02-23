using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChange : MonoBehaviour
{

    public static int RandomizeAttribute()
    {
        return (int)UnityEngine.Random.Range(0, 3);
    }

    public static int RandomizeValue()
    {
        return (int)UnityEngine.Random.Range(-2, 10);
    }
}
