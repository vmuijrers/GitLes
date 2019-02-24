using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public int maxObjects = 100;
    public Vector3 area;
    private GameObject[] objects;
    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Start() {
        objects = Resources.LoadAll<GameObject>("Objects");
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects() {
        int numObjects = 0;
        while (numObjects < maxObjects) {
            yield return null;
            Vector3 position = new Vector3(
                Random.Range(0.5f * -area.x, 0.5f * area.x),
                0,
                Random.Range(0.5f * -area.z, 0.5f * area.z)); 
            Quaternion rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            spawnedObjects.Add(Instantiate(objects[Random.Range(0, objects.Length)], position, rotation));
            numObjects++;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, area);
    }
}
