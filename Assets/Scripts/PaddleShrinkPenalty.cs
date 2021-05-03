using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleShrinkPenalty : MonoBehaviour
{
    public GameObject paddle1;
    public GameObject paddle2;
    private Vector3 startSize;
    private Vector3 scaleChange;
    private Vector3 maxLocalScale;
    float maxScaleChangeMagnitude;
    float actualScaleMagnitude;

    // Start is called before the first frame update
    void Start()
    {
        startSize = paddle1.transform.localScale;
        paddle1 = GameObject.Find("PlayerPaddle");
        paddle2 = GameObject.Find("PlayerPaddle (1)");
        maxLocalScale = new Vector3(2, 1, 1);
        maxScaleChangeMagnitude = maxLocalScale.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shrinkPaddle()
    {
        actualScaleMagnitude = transform.localScale.magnitude;
        if (actualScaleMagnitude >= maxScaleChangeMagnitude)
        {
            paddle1.transform.localScale += new Vector3(-1, 0, 0);
            paddle2.transform.localScale += new Vector3(-1, 0, 0);
        }
    }

    public void resetPaddle()
    {
        paddle1.transform.localScale = startSize;
        paddle2.transform.localScale = startSize;
    }
}
