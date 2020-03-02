using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    private Canvas canvas;
    private Image factionIcon;

    private int population;
    private float others;
    private float trend;

    private float smsFatigue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        factionIcon = GetComponentInChildren<Image>();

        canvas.transform.eulerAngles -= new Vector3(0, transform.eulerAngles.y, 0);
        // canvas.transform.SetParent(null);

        others = UnityEngine.Random.Range(0f, 1f);
        trend = UnityEngine.Random.Range(-0.04, +0.04);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        others = Mathf.Clamp(others, 0, 1);
        factionIcon.color = new Color(others, 0, 1 - others, 1);

        others += trend;
    }

    public void Clicked()
    {
        if (Global.tool == "SMS") {
            if (Global.others) {
                others += 0.02f;
            } else {
                others -= 0.02f;
            }
        }
        
        smsFatigue = Math.Max(0f, smsFatigue - 0.1f);
    }

}
