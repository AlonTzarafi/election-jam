using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    GameObject smsPrefab1;
    GameObject smsPrefab2;

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
        ResetTrend();
    }

    public void ResetTrend()
    {
        var trendMax = 0.003f;
        var a = -trendMax;
        var b = trendMax;
        if (UnityEngine.Random.Range(0, 3) == 0) {
            a *= 0;
            b *= 2;
        } else if (UnityEngine.Random.Range(0, 3) == 0) {
            a *= 2;
            b *= 0;
        }
        trend = UnityEngine.Random.Range(a, b);
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
            Debug.Log("Activating SMS on ", this);
            var thePrefab = smsPrefab1;
            if (Global.others) {
                others += SMSPower();
                thePrefab = smsPrefab2;
            } else {
                others -= SMSPower();
            }
            //effect
            Vector3 mousePos=new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
            
            if(Input.GetMouseButtonDown(0)) {
                Vector3 wordPos;
                Ray ray=Camera.main.ScreenPointToRay(mousePos);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit,1000f)) {
                    wordPos=hit.point;
                } else {
                    wordPos=Camera.main.ScreenToWorldPoint(mousePos);
                }
                Instantiate(thePrefab,wordPos,Quaternion.identity); 
                //or for tandom rotarion use Quaternion.LookRotation(Random.insideUnitSphere)
            }
        } else if (Global.tool == "Powerout") {
            powerout = 10f;
        } else if (Global.tool == "???????????????????????") {
        }
        
        smsFatigue = Mathf.Max(0f, smsFatigue - 0.1f);
    }

    private float SMSPower()
    {
        return 0.08f;
    }

}
