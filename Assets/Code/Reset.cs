using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void loadScene(string wool)
    {
        SceneManager.LoadScene(wool);
    }
}
