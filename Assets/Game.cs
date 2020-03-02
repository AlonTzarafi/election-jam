using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Area[] areas;
    
    Image othersStatus;
    
    // Start is called before the first frame update
    void Start()
    {
        othersStatus = GameObject.Find("othersStatus").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float totalOthers = 0;
        foreach (var area in areas)
        {
            totalOthers += area.others;
        }
        var result = totalOthers / areas.Length;
        
        othersStatus.fillAmount = result;
    }
}
