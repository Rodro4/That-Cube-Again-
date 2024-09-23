using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool rightIsPressed;
    private GameObject player;

    private void Start()
    {
        rightIsPressed = false;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (rightIsPressed)
        {
            player.GetComponent<PlayerMovement>().MoveRight();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rightIsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rightIsPressed = false;
    }
}
