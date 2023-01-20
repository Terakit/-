using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlay : MonoBehaviour
{
    public Camera Cam;
    public GameLogic GL;
    RaycastHit hit;
    void Update()
    {
        if (GL.Drag)
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(ray, out hit, 100f) && hit.collider.tag == ("Тайл") && hit.collider.GetComponent<Resources>().Type >= 0)
                {
                    GL.PosTile = new Vector2Int(Mathf.RoundToInt(hit.transform.position.x), Mathf.RoundToInt(hit.transform.position.z));
                    GL.Invoke("GetTiles", 0);
                    GL.Drag = false;
                }
            }
        }
    }
}
