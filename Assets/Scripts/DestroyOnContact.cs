using System;
using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
    

    void OnTriggerEnter2D(Collider2D second)
    {

        Destroy(second.gameObject);
    }

}
