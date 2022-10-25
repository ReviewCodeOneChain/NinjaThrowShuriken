using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ThrowShurikenScript : MonoBehaviour
{

    [SerializeField] GameObject Shuriken;
    [SerializeField] float LaunchForce = 15;

    Vector2 endPoint;
    Vector2 startPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pressed
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //released
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            throwShuriken();
        }
    }

    void throwShuriken()
    {
        //Clone
        GameObject shurikenIns = Instantiate(Shuriken, transform.position, transform.rotation);
        //Passing a value to parameter
        shurikenIns.GetComponent<SpinShuriken>().setForce(transform.position, -(endPoint - startPoint),LaunchForce);
        //shurikenIns.GetComponent<Rigidbody2D>().velocity = -(endPoint - startPoint) * LaunchForce;
        //shurikenIns.GetComponent<Rigidbody2D>().AddForce(-(endPoint - startPoint) * LaunchForce);
    }
}
