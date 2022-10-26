using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShuriken : MonoBehaviour
{
    Vector2 startPos;
    Vector2 direction;
    [SerializeField]  float force;
    [SerializeField]  float time;

    public void setForce(Vector2 startPos, Vector2 direction, float force)
    {
        this.startPos = startPos;
        this.direction = direction;
        this.force = force;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Xoay khi b? ném
        transform.Rotate(0, 0, -72f);

        //V? trí c?a nhân v?t thay ??i theo time
        //time += Time.deltaTime;
        //transform.position = startPos + (direction * force * time) + 0.5f * Physics2D.gravity * (time * time);
        time += Time.deltaTime;
        transform.position = shurikenPos(time);

        float t2 = time + Time.deltaTime;

        Vector2 posFuture = shurikenPos(t2);
        Vector2 directionFuture = posFuture - (Vector2)transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionFuture, Vector2.Distance(transform.position, posFuture));
        if (hit.collider.transform.CompareTag("Target"))
        {
            Destroy(gameObject);
            Destroy(hit.collider.gameObject);
            //Debug.Log(hit.collider.name);
        }
    }   

    private Vector2 shurikenPos(float t)
    {
        return startPos + (direction * force * t) + 0.5f * Physics2D.gravity * (t * t);
    }

    //Two objects colliding
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Target"))
    //    {
    //        Destroy(gameObject);
    //        Destroy(collision.gameObject);
    //    }    
    //}
}
