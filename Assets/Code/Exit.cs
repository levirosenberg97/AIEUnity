using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {



    public void End()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }
}
