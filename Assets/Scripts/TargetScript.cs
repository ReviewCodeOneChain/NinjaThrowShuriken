using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] float posMinY = -5f;
    [SerializeField] float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Find object Spawner
        spawner = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        //Move down
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        //If the screen boundary is exceeded -> delete the object
        if (transform.position.y < posMinY)
        {
            Destroy(gameObject);
        }
    }

    //When this object is destroyed then call SpawnerRandomTarget -> let another object appear from pool target
    private void OnDestroy()
    {
        spawner.GetComponent<SpawnerScript>().SpawnerRandomTarget();
    }
}
