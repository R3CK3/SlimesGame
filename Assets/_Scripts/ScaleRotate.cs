using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRotate : MonoBehaviour
{
    public float scaleTime = 2f;
    private float scale = 1f;
    public float rotateAmount = 2f;
    public float scaleAmount = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ScaleObject());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateAmount);
        transform.localScale += new Vector3(1f, 1f, 1f) * scale * scaleAmount;
    }

    private IEnumerator ScaleObject()
    {
        yield return new WaitForSeconds(scaleTime);
        scale = -scale;
        yield return ScaleObject();
    }
}
