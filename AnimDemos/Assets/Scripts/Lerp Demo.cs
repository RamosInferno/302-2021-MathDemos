using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpDemo : MonoBehaviour
{
    public GameObject objectStart;
    public GameObject objectEnd;

    [Range(-1, 2)] public float percent = 0;


    public float animationLength = 2;
    private float animationPlayheadTime = 0;
    private bool isAnimPlaying = false;

    public AnimationCurve animationCurve;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAnimPlaying) {

            animationPlayheadTime += Time.delta
            percent = animationPlayheadTime / animationLength;
            percent = Mathf.Clamp(percent, 0, 1);

            percent = percent * percent * (3 - 2 * percent); // ease in is speeding up

            percent = animationCurve.Evaluate(percent, 0, 1);

            float p = animationCurve.Evaluate(percent);
            print(percent);

            DoTheLerp(p);

            if (percent >= 1) isAnimPlaying = false;
        }

    }
    private void DotheLerp(float p)
    {
       transform.position = AnimMath.Lerp(
         objectStart.transfom.position, objectEnd.transform.position  )
    }
    public void PlayTweenAnim()
    {
        isAnimPlaying = true;
        animationPlayheadTime = 0;
    }

    private void OnValidate()
    {
        DotheLerp(percent);
    }
}
