using UnityEngine;
using UnityEngine.InputSystem;

public class SoilTileScript : MonoBehaviour
{
    public bool isOccupied = false;
    public GameObject plantPrefab;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) //left click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                SoilTileScript tile = hit.collider.GetComponent<SoilTileScript>();
                if (tile != null && !tile.isOccupied)
                {
                    Vector3 spawnPosition = hit.point + new Vector3(0, 0.5f, 0);
                    GameObject newPlant = Instantiate(plantPrefab, spawnPosition, Quaternion.identity);
                    tile.isOccupied = true;

                    //link this tile to plant script
                    PlantScript plantScript = newPlant.GetComponent<PlantScript>();
                    if (plantScript != null) plantScript.assignedTile = this;
                }
            }
        }
    }
}