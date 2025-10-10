using UnityEngine;

public class Fitinlsot : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Slot"))
            Debug.Log("Item placed in slot");
        // other.GetComponent<Slot>().isEmpty = false;
        GetComponent<Draggable>().dragging = false;
        transform.position = other.transform.position;


    }
       
   }

