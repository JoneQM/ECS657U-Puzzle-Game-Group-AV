using UnityEngine;
using UnityEditor;

public class AdvancedRenamer : MonoBehaviour
{
    [MenuItem("MyTools/Rename Children by Type")]
    static void RenameChildrenByType()
    {
        GameObject parentObject = Selection.activeGameObject; // Select the parent in the hierarchy

        if (parentObject != null)
        {
            int trapCount = 1;
            int grassCount = 1;
            int waterCount = 1;
            int bridgeCount = 1;
            int starCount = 1;
            int waypointCount = 1;
            int bluePlatformCount = 1;
            int redPlatformCount = 1;

            foreach (Transform child in parentObject.transform)
            {
                if (child.name.Contains("Trap"))
                {
                    child.name = "Trap " + trapCount++;
                }
                else if (child.name.Contains("Grass"))
                {
                    child.name = "Grass " + grassCount++;
                }
                else if (child.name.Contains("Water"))
                {
                    child.name = "Water " + waterCount++;
                }
                else if (child.name.Contains("Bridge"))
                {
                    child.name = "Bridge " + bridgeCount++;
                }
                else if (child.name.Contains("Star"))
                {
                    child.name = "Star" + starCount++;
                }
                else if (child.name.Contains("Waypoint"))
                {
                    child.name = "Waypoint" + waypointCount++;
                }
                else if (child.name.Contains("Button Platform"))
                {
                    child.name = "Button Platform " + bluePlatformCount++ + " Blue";
                }
                else if (child.name.Contains("Button Platform  "))
                {
                    child.name = "Button Platform  " + redPlatformCount++ + " Red";
                }
            }
        }
        else
        {
            Debug.LogError("You must select a parent object in the hierarchy");
        }
    }
}
