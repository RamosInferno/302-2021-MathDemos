using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierQuadratic : MonoBehaviour
{

    public Transform positionA;
    public Transform positionB;
    public Transform handle;

    public float percent = 0;

    public int curveResolution = 10;

    [Header("Tween Stuff")]
    [Tooltip("How long the tween shoiuld take, in seconds.")]
    [Range(.1f, 10)] public float tweenLength = 3;
    public AnimationCurve tweenSpeed;

    public void PlayTween()
    {
        isTweening = true;
        tweenTimer = 0;
    }
    private float tweenTimer = 0;
    private bool isTweening = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTweening)
        {
            tweenTimer += Time.deltaTime;
            float p = tweenTimer / tweenLength;
            percent = tweenSpeed.Evaluate(p);

            if (tweenTimer > tweenLength) isTweening = false;
        }

        transform.position = CalcPositionOnCurve(percent);
    }

    private Vector3 CalcPositionOnCurve(float percent)
    {
        Vector3 c = AnimMath.Lerp(positionA.position, handle.position, percent);
        Vector3 d = AnimMath.Lerp(handle.position, positionB.position, percent);

        Vector3 f = AnimMath.Lerp(c, d, percent);

        return f;
    }

    private void OnDrawGizmos()
    {
        Vector3 p1 = positionA.position;

        for(int i =1; i < curveResolution; i++)
        {
            float p = i / (float)curveResolution;

            Vector3 p2 = CalcPositionOnCurve(p);

            Gizmos.DrawLine(p1, p2);
            p1 = p2;
        }

        Gizmos.DrawLine(p1, positionB.position);

    }

}

[CustomEditor(typeof(BezierQuadratic))]

public class BezierQuadraticEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


       if( GUILayout.Button("Play Tween"))
        {
            (target as BezierQuadratic).PlayTween();
        }
    }
}

