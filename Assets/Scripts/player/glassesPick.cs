using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassesPick : MonoBehaviour
{

    public eyeSight look;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Glasses")
        {
            look.GlassPickUp();
            Destroy(other.gameObject);
        }
    }
}
