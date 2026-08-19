using UnityEngine;

public class Spawner_Time : MonoBehaviour
{
    public float spawnInterval = 2f; // Time interval between spawns in seconds
    private float spawnTimer = 0f; // Timer to track time since last spawn
    public GameObject spawnPrefab;

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Spawner.instance.Spawn(spawnPrefab);
        }
    }
}
