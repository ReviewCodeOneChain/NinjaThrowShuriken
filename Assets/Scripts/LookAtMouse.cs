using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    Vector2 Direction;
    [SerializeField] float force = 15;
    [SerializeField] GameObject PointPrefab;
    [SerializeField] GameObject PointSpawner;
    [SerializeField] GameObject[] Point;
    [SerializeField] int numberOfPoints;
    Vector2 endPoint;
    Vector2 startPoint;
    // Start is called before the first frame update
    void Start()
    {
        Point = new GameObject[numberOfPoints]; //Truyen vao so luong

        for (int i = 0; i < numberOfPoints; i++)
        {
            Point[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
            Point[i].transform.parent = PointSpawner.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition; //vi trí ctc

        //Nhan vat huong ve phia ctc
        //Direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        //transform.right = Direction;

        //pressed
        //Input.GetKeyDown(KeyCode.Mouse0) -> ngat quang?
        if (Input.GetMouseButtonDown(0))
        {
            //Chuyen doi diem tu space man hinh sang khong gian the gioi trong game
            startPoint = Camera.main.ScreenToWorldPoint(mousePos);
        }

        //released
        if (Input.GetMouseButton(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(mousePos);
        }

        //-----------------
        for (int i = 0; i < Point.Length; i++)
        {
            //Gia tri cua vi tri ham PointPosition tra ve gan vao tung vi tri cua Point
            Point[i].transform.position = PointPosition(i * 0.1f);
        }
    }

    Vector2 PointPosition(float time)
    {
        //Doi chieu am de lam luc keo: chieu ctc keo >doi nghich< chieu di chuyen cua doi tuong Shuriken
        Vector2 direction = -(endPoint - startPoint);
        Vector2 currentPointPos = (Vector2)transform.position + (direction * force * time) + 0.5f * Physics2D.gravity * (time * time);

        return currentPointPos;
    }
}
