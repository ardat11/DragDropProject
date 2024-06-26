using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MidUpdate : MonoBehaviour
{
    public static MidUpdate Instance;
    public Material[] materials;
    public Renderer rend;
    public float sayac;

    public int colorsadded;

    public bool red;
    public bool green;
    public bool blue;
    public bool magenta;
    //BURAYA BOOLLAR EKLENECEK

    public float transformsayac;


    public Color[] colors;

    public Color prevc;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
        transformsayac *= Time.deltaTime;
    
    }

    private void Update()
    {
        sayac -= Time.deltaTime;
    
    
        if(sayac < 0)
        {
            meshupdater();

        }
    




    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("K�rm�z�"))
        {
            if (red != true)
            {
                if (colorsadded == 1)
                {
                    rend.sharedMaterial = materials[1];
                    prevc = rend.sharedMaterial.color;
                }

                colorsadded++;
                
                red = true;
                
            }
        }

        if (collision.gameObject.CompareTag("Mavi"))
        {
            if (blue != true)
            {
                if (colorsadded == 1)
                {
                    rend.sharedMaterial = materials[3];
                    prevc = rend.sharedMaterial.color;
                }
                colorsadded++;
                
                blue = true;
                
            }

        }
        if (collision.gameObject.CompareTag("Yeshil"))
        {
            if (green != true)
            {
                if (colorsadded == 1)
                {
                    rend.sharedMaterial = materials[2];
                    prevc = rend.sharedMaterial.color;
                }
                colorsadded++;
                
                green = true;
                
            }

        }

        if (collision.gameObject.CompareTag("Reseter"))
        {
            colorsadded = 0;
            red = false; green = false; blue = false;
            colorreset();
            ScoreManager.instance.Sphere1.SetActive(true);
            ScoreManager.instance.Sphere2.SetActive(true);
            ScoreManager.instance.Sphere3.SetActive(true);



        }












    }

    private void meshupdater()
    {
        if (colorsadded == 2)
        {
            if (red && green)
            {
                //rend.sharedMaterial = materials[5];

                transformsayac += Time.deltaTime / 150;
                rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Color.yellow, transformsayac);
            }
            else if (red && blue)
            {
                //rend.sharedMaterial = materials[4];
                transformsayac += Time.deltaTime / 150;
                rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Color.magenta, transformsayac);
            }
            else if (blue && green)
            {
                //rend.sharedMaterial = materials[6];
                transformsayac += Time.deltaTime / 150;
                rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Color.cyan, transformsayac);
            }
        }
        else if (colorsadded == 3)
        {
            if (red && green && blue)
            {
                //rend.sharedMaterial = materials[7];
                transformsayac += Time.deltaTime / 150;
                rend.sharedMaterial.color = Color.Lerp(rend.sharedMaterial.color, Color.white, transformsayac);
            }
        }

    }

    public void colorreset()
    {

        rend.sharedMaterial = materials[0];

    }

    IEnumerator WaitBeforeMixing(float sec)
    {
        yield return new WaitForSeconds(sec);
        meshupdater();



    }



}

















































    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("K�rm�z�"))
    //    {
    //        print("K�rm�z� de�di");
    //        colorsadded++;
    //        diziupdate();
    //        foreach (Renderer nesneRenderer in nesneRenderers)
    //        {              
    //            Color eskiRenk = nesneRenderer.material.color;


    //            Color yeniRenk = new Color(1,eskiRenk.g,eskiRenk.b,eskiRenk.a);


    //            nesneRenderer.material.color = yeniRenk;
    //        }
    //    }

    //    else if (collision.gameObject.CompareTag("Yeshil"))
    //    {   colorsadded++;
    //        diziupdate();
    //        foreach (Renderer nesneRenderer in nesneRenderers)
    //        {
    //            Color eskiRenk = nesneRenderer.material.color;


    //            Color yeniRenk = new Color(eskiRenk.r,1 , eskiRenk.b, eskiRenk.a);


    //            nesneRenderer.material.color = yeniRenk;
    //        }
    //    }

    //    else if (collision.gameObject.CompareTag("Mavi"))
    //    {
    //        colorsadded++;
    //        diziupdate();
    //        foreach (Renderer nesneRenderer in nesneRenderers)
    //        {
    //            Color eskiRenk = nesneRenderer.material.color;


    //            Color yeniRenk = new Color(eskiRenk.r, eskiRenk.g, 1, eskiRenk.a);


    //            nesneRenderer.material.color = yeniRenk;
    //        }
    //    }










    //}

    //private void diziupdate()
    //{
    //    if(colorsadded == 2)
    //    {
    //        Array.Resize(ref nesneRenderers, nesneRenderers.Length + 1);
    //        nesneRenderers[nesneRenderers.Length - 1] = Mid;
    //    }
    //    else if (colorsadded == 3)
    //    {
    //        Array.Resize(ref nesneRenderers, nesneRenderers.Length + 1);
    //        nesneRenderers[nesneRenderers.Length - 1] = Top;
    //    }

    //}












