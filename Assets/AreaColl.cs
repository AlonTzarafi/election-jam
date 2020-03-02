using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaColl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit  hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform == transform) {
                    var area = GetComponentInParent<Area>();
                    area.Clicked();
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            RaycastHit  hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform == transform) {
                    var area = GetComponentInParent<Area>();
                    area.Clicked(true);
                }
            }
        }
    }

    // void OnMouseDown()
    // {
    //     var area = GetComponentInParent<Area>();
    //     // Debug.Log("Clicked area ", area);
    //     area.Clicked();
    // }
}
