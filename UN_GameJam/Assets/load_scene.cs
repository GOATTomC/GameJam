using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class load_scene : MonoBehaviour
{

    public void Load_scene_Main()
    {
        SceneManager.LoadScene("GenScene");
    }
    public void Load_scene_Options()
    {
        SceneManager.LoadScene("Options");
    }
}
