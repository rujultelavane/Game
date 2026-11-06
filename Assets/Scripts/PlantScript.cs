using System;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public float growthSpeed = 0.2f;
    public float maxHeight = 3.0f;
    public float swaySpeed = 2.0f;
    public float swayAngle = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //growing (vertical scale)
        if (transform.localScale.y < maxHeight)
        {
            transform.localScale += new Vector3(0, growthSpeed * Time.deltaTime, 0);
        }

        //swaying
        float zRotation = Mathf.Sin(Time.time * swaySpeed) * swayAngle;
        transform.localRotation = Quaternion.Euler(0, 0, zRotation);

    }
}
