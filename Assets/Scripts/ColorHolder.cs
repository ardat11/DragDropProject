using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColorHolder : MonoBehaviour
{


    private float horizontal;
    private float vertical;
    private bool holding;

    private Vector3 startpos;
    [SerializeField] private GameObject sphere;

    public float speed;
    private void Start()
    {
        
        startpos = transform.position;

    }

    private void Update()
    {
        horizontal = Input.GetAxis("Mouse X");
        vertical = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            holding = true;
            Cursor.visible = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            holding = false;
            Cursor.visible = true;
            transform.position = startpos;
        }








    }

    private void OnMouseDrag()
    {
        if (holding)
        {

            transform.position += new Vector3(horizontal / speed, vertical / speed, 0);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Blender"))
        {
            transform.position = startpos;
            sphere.SetActive(false);

        }
    }


    //private void OnMouseDrag()
    //    {
    //        transform.position= Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    }

    //    private Vector3 Nesneekrankonum()
    //    {
    //        return Camera.main.WorldToScreenPoint(transform.position);

    //    }









}
