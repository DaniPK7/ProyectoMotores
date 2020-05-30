using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class softTransition : MonoBehaviour
{

    public Animator alphaAnim;
    // Start is called before the first frame update
    public void alphaTransition() 
    {
        alphaAnim.SetTrigger("Goes");
    }
    public void LoadNext() 
    {
        SceneManager.LoadScene("PostGame");
    }
}
