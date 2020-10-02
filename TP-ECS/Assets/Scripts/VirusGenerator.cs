using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[DisallowMultipleComponent]
public class VirusGenerator : MonoBehaviour
{
    public GameObject virusPrefab;

    public float reloadTime = 2f;
    public float reloadProgress = 0f;

    // Update is called once per frame
    void Update()
    {
        reloadProgress += Time.deltaTime;
        if(reloadProgress >= reloadTime)
        {
            Instantiate<GameObject>(virusPrefab);
            reloadProgress = 0;
        }
    }
}
