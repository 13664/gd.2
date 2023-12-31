using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController2D character;
    Rigidbody2D rigidbody2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractable = 1.2f;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }


    private void UseTool()
    {
        Vector2 position = rigidbody2d.position +  character.lastMotionVector * sizeOfInteractable;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractable);
        foreach(Collider2D c in  colliders)
        {
            ToolKit hit = c.GetComponent<ToolKit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
    
    }
}
