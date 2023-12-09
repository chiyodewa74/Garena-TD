using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        UpdateCursor();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, PlayerMovementController.Instance.transform.position);
    }

    public void UpdateCursor()
    {
        // Get the current cell coordinates based on the object's position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    }
}
