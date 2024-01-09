using System.Collections;
using UnityEngine;
using Unity.AI.Navigation;
using System.Collections.Generic;

public class InteractableYellowTile : MonoBehaviour
{
    public LayerMask playerLayer; 
    private NavMeshSurface navMeshSurface; 
    [SerializeField]
    private GameObject preMadePath;

    [Header("Build")]
    [SerializeField]
    private GameObject pathTilePrefab;
    [SerializeField]
    private Transform beginningPathTile, endPathTile, endPathTile2;
    [SerializeField]
    private float tilePlacementInterval = 0.6f;
    [SerializeField]
    private bool placeEndPathTile = false;

    private Transform currentPathTile;
    private bool isPathPlaced = false;

    private void Start()
    {
        // Cache the NavMeshSurface component at start
        navMeshSurface = Object.FindFirstObjectByType<NavMeshSurface>();

        if(preMadePath != null)
        {
            StartCoroutine(ShowPremadePath(false, 0f));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BuildPath());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player using the layer mask
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            StartCoroutine(ShowPath());
        }
    }

    private IEnumerator ShowPath()
    {
        if (preMadePath != null && !isPathPlaced)
        {
            isPathPlaced = true;
            yield return ShowPremadePath(true, tilePlacementInterval);
            RebuildNavMesh();
        }

        yield return null;
    }

    private IEnumerator ShowPremadePath(bool show, float interval)
    {
        for (int i = 0; i < preMadePath.transform.childCount; i++)
        {
            preMadePath.transform.GetChild(i).gameObject.SetActive(show);
            yield return new WaitForSeconds(interval);
        }
    }


    private IEnumerator BuildPath()
    {
        if (!isPathPlaced)
        {
            isPathPlaced = true;
            currentPathTile = beginningPathTile;
            Vector3 spawnPos;
            bool isBridgeCompleted = false;
            float minPosNeeded = placeEndPathTile ? 1f : 1.1f;

            while (!isBridgeCompleted)
            {
                spawnPos = currentPathTile.position + (endPathTile.position - currentPathTile.position).normalized;
                currentPathTile = Instantiate(pathTilePrefab, spawnPos, Quaternion.identity, preMadePath.transform).transform;
                yield return new WaitForSeconds(tilePlacementInterval);

                isBridgeCompleted = Vector3.Distance(currentPathTile.position, endPathTile.position) < minPosNeeded;
                Debug.Log(isBridgeCompleted);

                if (isBridgeCompleted && endPathTile2 != null)
                {
                    currentPathTile = endPathTile;
                    endPathTile = endPathTile2;
                    endPathTile2 = null;
                    isBridgeCompleted = false;
                }
            }

            RebuildNavMesh();
        }
    }

        private void RebuildNavMesh()
        {
            Object.FindFirstObjectByType<NavMeshSurface>().BuildNavMesh();
        }
}

