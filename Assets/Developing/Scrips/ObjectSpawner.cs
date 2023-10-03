using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spherePrefab;
    public GameObject cubePrefab;
    public Material targetMaterial;
    public float spawnRadius = 3.0f;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnedObjects.Clear();
            for (int i = 0; i < 25; i++)
            {
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                GameObject objectToSpawn = Random.Range(0, 2) == 0 ? spherePrefab : cubePrefab;
                GameObject spawned = Instantiate(objectToSpawn, randomPos, Quaternion.identity);
                spawnedObjects.Add(spawned);
            }
            MarkRandomTarget();
        }
    }

    void MarkRandomTarget()
    {
        if (spawnedObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnedObjects.Count);
            GameObject targetObject = spawnedObjects[randomIndex];
            targetObject.tag = "Target";
            Renderer rend = targetObject.GetComponent<Renderer>();
            rend.material = targetMaterial;
        }
    }
}
