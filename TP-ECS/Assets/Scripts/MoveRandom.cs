using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{

    public float size = 10;
    private Vector3 point;

    // Start is called before the first frame update
    void Start()
    {
        point = GetNewRandompoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == point)
        {
            point = GetNewRandompoint();
        }

        if (point != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, point, Time.deltaTime);
        }

    }

    public Vector3 GetNewRandompoint()
    {
        return new Vector3(Random.Range(-size, size), Random.Range(-size, size), 0);
    }
}
