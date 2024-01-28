using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditorInputController : MonoBehaviour
{
    public GameObject uploadPanel;
    
    public ObjectSpawner objectSpawner;
    public Camera mainCamera;
    
    private void Update()
    {
        var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonDown(0))
        {
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null && hit.transform.GetComponent<EditorObjectHandler>())
            {
                objectSpawner.DestroyObj(hit.transform.gameObject);
                var objId = hit.transform.GetComponent<EditorObjectHandler>().objectId;
                if (objId >= objectSpawner.objects.Length - 1)
                    objId = -1;
                objectSpawner.SpawnObject(objId + 1, mousePosition);
            }
            else
            {
                objectSpawner.SpawnObject(0, mousePosition);
            }
        } else if (Input.GetMouseButtonDown(1))
        {
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider != null)
                objectSpawner.DestroyObj(hit.transform.gameObject);
        }
    }
    
    public void OpenUploadPanel() => uploadPanel.SetActive(true);
    
    public void CloseUploadPanel() => uploadPanel.SetActive(false);
}
