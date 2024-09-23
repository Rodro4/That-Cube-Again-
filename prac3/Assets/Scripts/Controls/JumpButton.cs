using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool jumpIsPressed;
    private GameObject player;

    private void Start()
    {
        jumpIsPressed = false;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (jumpIsPressed && CheckGround.onGround)
        {
            player.GetComponent<PlayerMovement>().Jump();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        jumpIsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jumpIsPressed = false;
    }
}
