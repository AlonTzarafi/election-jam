using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    private Canvas canvas;
    private Image factionIcon;

    public float others;

    // Always affects
    private float trend;

    // Maybe for later
    public int population;

    // poweroutpoweroutpoweroutpowerout
    private float powerout;

    private float smsFatigue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        factionIcon = GetComponentInChildren<Image>();

        canvas.transform.eulerAngles -= new Vector3(0, transform.eulerAngles.y, 0);
        // canvas.transform.SetParent(null);

        others = UnityEngine.Random.Range(0f, 1f);
        var trendMax = 0.004f;
        trend = UnityEngine.Random.Range(-trendMax, +trendMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        others += trend;

        powerout -= Time.fixedDeltaTime;
        
        //clean numbers
        others = Mathf.Clamp(others, 0, 1);
        // show support
        factionIcon.color = new Color(0, 1 - others, others, 1);
        //show blackout
        if (powerout >= 0) {
            factionIcon.color = new Color(0, 0, 0, 1);
        }
    }

    public void Clicked()
    {
        if (Global.tool == "SMS") {
            if (Global.others) {
                others += 0.02f;
            } else {
                others -= 0.02f;
            }
        } else if (Global.tool == "Powerout") {
            powerout = 10f;
        } else if (Global.tool == "???????????????????????") {
        }
        
        smsFatigue = Mathf.Max(0f, smsFatigue - 0.1f);
        smsFatigue = Mathf.Max(0f, smsFatigue - 0.1f);
    }

}
