using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ChangeCollorOnEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChangeCollorOnExit();
            Invoke("FallDown", 5.5f);
            FallDown();
        }
    }

    void ChangeCollorOnEnter()
    {
        Renderer myRenderer = GetComponentInParent<Renderer>();
        myRenderer.material.color = Color.green;
        Debug.Log("Player Collided with CUBE");
    }
    void ChangeCollorOnExit()
    {
        Renderer myRenderer = GetComponentInParent<Renderer>();
        myRenderer.material.color = Color.black;
        Debug.Log("CUBE falling down");
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;

        Destroy(transform.parent.gameObject, 3f);

    }
}
