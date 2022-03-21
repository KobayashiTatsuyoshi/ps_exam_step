using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public System.Action<Vector2> playerAttack;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerAttack(worldMousePos);
        }
    }
}
