using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlantScript : MonoBehaviour
{
    public float growthSpeed = 0.2f;
    public float maxHeight = 2.0f;
    public float swaySpeed;
    public float swayAngle;
    public SoilTileScript assignedTile; //which tile the plant is on

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swaySpeed = UnityEngine.Random.Range(0.5f, 2.0f);
        swayAngle = UnityEngine.Random.Range(1.0f, 5.0f);

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
    void OnMouseOver() //right click for pruning/deleting plant
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            //free soil space so you can plant another one
            if (assignedTile != null)
            {
                assignedTile.isOccupied = false;
            }
            Destroy(gameObject); //delete plant
        }
    }
}
