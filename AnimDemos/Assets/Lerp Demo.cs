using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public GameObject objectStart;
    public GameObject objectEnd;

    [Range(0, 1)] public float percent = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(objectStart.transform.position, objectEnd.transform.position, percent);

    }
}
