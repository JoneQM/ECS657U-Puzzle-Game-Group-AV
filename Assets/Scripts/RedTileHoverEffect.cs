using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTileHoverEffect : MonoBehaviour
{
    public GameObject[] associatedTraps; // Assign in the inspector
    public Material outlineMaterial; // Assign a material with an outline effect in the inspector
    private Material[] originalMaterials; // To store the original materials

    void Start()
    {
        // Store the original materials of the traps
        originalMaterials = new Material[associatedTraps.Length];
        for (int i = 0; i < associatedTraps.Length; i++)
        {
            originalMaterials[i] = associatedTraps[i].GetComponent<Renderer>().material;
        }
    }

    void OnMouseEnter()
    {
        // Change the material of the traps to the outline material when the mouse enters the red tile
        foreach (var trap in associatedTraps)
        {
            trap.GetComponent<Renderer>().material = outlineMaterial;
        }
    }

    void OnMouseExit()
    {
        // Restore the original material when the mouse exits the red tile
        for (int i = 0; i < associatedTraps.Length; i++)
        {
            associatedTraps[i].GetComponent<Renderer>().material = originalMaterials[i];
        }
    }
}
