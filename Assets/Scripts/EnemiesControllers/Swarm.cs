using UnityEngine;

public class Swarm : MonoBehaviour
{
    public GameObject swarmPrefab;
    public int ammount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < ammount; i++)
        {
            Vector3 rndVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            Instantiate(swarmPrefab, transform.position + 6f * rndVector, Quaternion.identity);
            Spawner.instance.waveCurrentValue += swarmPrefab.GetComponent<Killable>().waveValue;
        }
    }
}
