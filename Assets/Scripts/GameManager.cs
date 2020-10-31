using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string[] elementNames = { "plastic", "wood", "rubber", "fibre", "wire", "metal", "cylinder", "electronic", "gas" };
    [SerializeField] GameObject[] garbageModels;
    [SerializeField] GameObject[] crushedGarbageModels;
    [SerializeField] GameObject[] produectModels;

    public GameObject GarbageInstantiator(int num)
    {
        return garbageModels[num];
    }
    public GameObject CrushedGarbageInstantiator(int num)
    {
        return crushedGarbageModels[num];
    }
    public GameObject ProductInstantiator(int num)
    {
        return produectModels[num];
    }

    public int GetRandomElements()
    {
        int num = Random.Range(0, 3);
        return num;
    }


}
