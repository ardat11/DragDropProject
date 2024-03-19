using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{   

    public static ScoreManager instance;
    public Color[] targetmaterials;

    public TMP_Text score;
    public TMP_Text losescore;
    public Renderer bottomrender;

    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject white;
    public GameObject magenta;
    public GameObject yellow;
    public GameObject cyan;
    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject Sphere3;



    private int prevtarget;



    private int target;
    public int skor;
    private bool iswaiting;

    public string TARGETPLS;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        anothertarget();
        score.text = "Skor: " + skor;

    }


    private void Update()
    {


        if(!iswaiting && FillBlender.Instance.achieved == TARGETPLS)
        {
            WinPanel.SetActive(true);
            skor++;
            score.text = "Skor: " + skor;
            StartCoroutine(WaitBeforeReset(3));
        }
        
        else if( FillBlender.Instance.sayac < 0 && FillBlender.Instance.achieved != TARGETPLS)
        {   
            LosePanel.SetActive(true);
            losescore.text = score.text;

            MidUpdate.Instance.rend.sharedMaterial.color = MidUpdate.Instance.prevc;
            FillBlender.Instance.rend.sharedMaterial.color = FillBlender.Instance.prevc;
            if (TopUpdate.Instance.colorsadded == 3)
            {
                TopUpdate.Instance.rend.sharedMaterial.color = TopUpdate.Instance.prevc;
            }





        }



    }

    private void anothertarget()
    {
        target = Random.Range(0, targetmaterials.Length);
        while(target == prevtarget)
        {
            target = Random.Range(0, targetmaterials.Length);
        }

        
        
        magenta.SetActive(false);
        yellow.SetActive(false);
        cyan.SetActive(false);
        white.SetActive(false);

        if (target == 0)
        {
            magenta.SetActive(true);
            TARGETPLS = "magenta";
        }

        else if (target == 1)
        {
            yellow.SetActive(true);
            TARGETPLS = "yellow";
        }
        else if (target == 2)
        {
            cyan.SetActive(true);
            TARGETPLS = "cyan";
        }
        else if (target == 3)
        {
            white.SetActive(true);
            TARGETPLS = "white";
        }

        prevtarget = target;
    }

    IEnumerator WaitBeforeReset(int sec)
    {   iswaiting = true;
        yield return new WaitForSeconds(sec);

        MidUpdate.Instance.rend.sharedMaterial.color = MidUpdate.Instance.prevc;
        FillBlender.Instance.rend.sharedMaterial.color = FillBlender.Instance.prevc;
        if (TopUpdate.Instance.colorsadded == 3)
        {
            TopUpdate.Instance.rend.sharedMaterial.color = TopUpdate.Instance.prevc;
        }

        TopUpdate.Instance.colorreset();
        MidUpdate.Instance.colorreset();
        FillBlender.Instance.colorreset();
        TopUpdate.Instance.red = false; TopUpdate.Instance.green = false; TopUpdate.Instance.blue = false; TopUpdate.Instance.colorsadded = 0;
        MidUpdate.Instance.red = false; MidUpdate.Instance.green = false; MidUpdate.Instance.blue = false; MidUpdate.Instance.colorsadded = 0;
        FillBlender.Instance.red = false; FillBlender.Instance.green = false; FillBlender.Instance.blue = false; FillBlender.Instance.colorsadded = 0;      
        WinPanel.SetActive(false);
        anothertarget();
        iswaiting = false;
        FillBlender.Instance.sayac = 15;
        MidUpdate.Instance.sayac = 15;
        TopUpdate.Instance.sayac = 15;
        Sphere1.SetActive(true);
        Sphere2.SetActive(true);
        Sphere3.SetActive(true);

    
    }

    IEnumerator Succesfull(int sec)
    {

        yield return new WaitForSeconds(sec);

    }






}
