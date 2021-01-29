using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class GenerateRingPath : MonoBehaviour
{
    [Range(10, 60)] public int num = 10;
    [Range(3, 20)] public float radius = 5;

    LineRenderer line;

    void Start()
    {
        generatepath();
    }

    void generatepath()
    {
        line = GetComponent<LineRenderer>();

        float rad = 0;

        Vector3[] pts = new Vector3[num];

        for (int i = 0; i < num; i++)
        {
            pts[i] = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;
            rad += Mathf.PI * 2 / num;
        }
        line.positionCount = num;
        line.SetPositions(pts);
    }

    void OnValidate()
    {
        generatepath();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
