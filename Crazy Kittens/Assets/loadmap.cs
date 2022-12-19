using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadmap : MonoBehaviour
{

    public GameObject map;
    public GameObject unloadMap;

    public void Start()
    {
        Physics.queriesHitTriggers = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        map.SetActive(true);
        unloadMap.SetActive(false);
    }
}