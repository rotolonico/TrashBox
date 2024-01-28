using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInputController : MonoBehaviour
{
    public ObjectSpawner objectSpawner;
    public Camera mainCamera;

    public int selectedObj;

    private void Update()
    {
        var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
                objectSpawner.DestroyObj(hit.transform.gameObject);
            else
                objectSpawner.SpawnObject(0, mousePosition);
        } else if (Input.GetMouseButtonDown(1))
        {
            
        }
    }
}
