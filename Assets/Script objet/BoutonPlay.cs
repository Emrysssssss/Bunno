using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPlay : MonoBehaviour
{
    public void changeScene(string _sceneName)
    {
        SceneManager.LoadScene (1);
    }
    public void Quit()
    {
        Application.Quit ();
    }
}
