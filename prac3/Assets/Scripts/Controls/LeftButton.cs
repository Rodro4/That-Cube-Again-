using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool leftIsPressed;
    private GameObject player;

    private void Start()
    {
        leftIsPressed = false;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (leftIsPressed)
        {
            player.GetComponent<PlayerMovement>().MoveLeft();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        leftIsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        leftIsPressed = false;
    }
}
