using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 offset;
    Rigidbody2D rb;
  public  bool dragging = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private Vector3 GetMouseWorldPos()
    {

        Vector3 mousePoint = Mouse.current.position.ReadValue();




        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePoint.x, mousePoint.y, 0));


        worldPos.z = 0;
        return worldPos;
    }
    
    
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            
            RaycastHit2D hit = Physics2D.Raycast(GetMouseWorldPos(), Vector2.zero);
            if (hit.collider != null && hit.collider.attachedRigidbody == rb)
            {
                if (!dragging)
                { Debug.Log("Start Dragging");
                    dragging = true;
                    offset = transform.position - GetMouseWorldPos();
                }

            }

        }
        if (Mouse.current.leftButton.wasReleasedThisFrame && dragging)
        {
            dragging = false;
        }
    }
    void FixedUpdate()
    {
        
        if (dragging)
        { Debug.Log("Dragging phys");
            Vector2 mouseWorldPos = GetMouseWorldPos();
            rb.MovePosition(mouseWorldPos + (Vector2)offset);
        }
    }


}
