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
        
    }

    void OnMouseDown()
    {
        var area = GetComponentInParent<Area>();
        // Debug.Log("Clicked area ", area);
        area.Clicked();
    }
}
