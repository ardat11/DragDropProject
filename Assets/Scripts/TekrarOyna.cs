using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TekrarOyna : MonoBehaviour
{


    private void OnMouseDown()
    {
        tekraroyna();
    }

    public void tekraroyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }





}
