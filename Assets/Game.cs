using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    float delayBetweenChangeTrends = 2f;

    [SerializeField]
    private Area[] areas;
    
    Image othersStatus;

    private float timeUntilElections = 10f;
    private float timeUntilNextTrend = 0;

    // Start is called before the first frame update
    void Start()
    {
        othersStatus = GameObject.Find("othersStatus").GetComponent<Image>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float totalOthers = 0;
        Global.powerOuts = 0;
        foreach (var area in areas)
        {
            if (area.powerout > 0) {
                Global.powerOuts++;
            } else {
                // Count only active regions
                totalOthers += area.others;
            }
        }
        var result = totalOthers / (areas.Length - Global.powerOuts);
        
        othersStatus.fillAmount = result;

        timeUntilNextTrend -= Time.deltaTime;
        if (timeUntilNextTrend < 0) {
            timeUntilNextTrend = delayBetweenChangeTrends;
            var areaToChange = areas[UnityEngine.Random.Range(0, areas.Length)];
            areaToChange.ResetTrend();
        }

        timeUntilElections -= Time.deltaTime;
        var secondsToElectionString = "" + Mathf.Floor(timeUntilElections);

        // elections
        if (timeUntilElections < 0) {
            timeUntilElections = 10;
            if (result < 0.4f || result > 0.6f) {
                // Game over
                Debug.Log("You lose!");
            }
        }

        //update text
        var timeToElections = GameObject.Find("timeToElections").GetComponent<Text>();
        timeToElections.text = "Time to elections: " + secondsToElectionString;


    }

    public void ChangeFaction(bool others)
    {
        Global.others = others;
    }
}
