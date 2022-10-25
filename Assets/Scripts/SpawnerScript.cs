using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] TargetPrefabs;
    [SerializeField] GameObject newTarget;
    [SerializeField] float posMaxX = 8f;
    [SerializeField] float posMinX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnerRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Take random target and appear within x limit
    public void SpawnerRandomTarget()
    {
        if (GameObject.FindWithTag("Target") != null)
        {
            return;
        }
        float randomX = Random.Range(posMinX, posMaxX);
        //float randomY = Random.Range(posMinY, posMaxY);
        int index = Random.Range(0, TargetPrefabs.Length);
        //Instantiate(Object original, Vector2 position, Quaternion rotation);
        newTarget = Instantiate(TargetPrefabs[index], new Vector2(randomX, 6f), transform.rotation);
    }
}
