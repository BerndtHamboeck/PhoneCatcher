using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {


    void OnMouseDown()
    {
        Application.LoadLevel(Application.loadedLevel);
        
    }

}
