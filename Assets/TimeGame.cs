using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundStartDelayTime = 3;
    float roundStartTime;
    int waitTime;
    bool roundStarted; // auto false

    // Start is called before the first frame update
    void Start()
    {
        print("Press the space bar once you think the allotted time is up.");
        Invoke("SetNewRandomTime", roundStartDelayTime);
        // SetNewRandomTime();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
            InputReceived();
        }
    }

    void InputReceived() 
    {
        float playerWaitTime = Time.time - roundStartTime;
        float error = Mathf.Abs(waitTime - playerWaitTime);

        print(GenerateMessage(error) + " You waited for " + playerWaitTime + " seconds. That's " + error + " seconds off.");
        Invoke("SetNewRandomTime", roundStartDelayTime);
        // SetNewRandomTime();
        roundStarted = false;
    }

    string GenerateMessage(float error)
    {
        string message = "";
        if (error < .15f)
        {
            message = "Damn best my man!";
        }
        else if (error < .75f)
        {
            message = "That's great!";
        }
        else if (error < 1.25f)
        {
            message = "Acceptable, good.";
        }
        else
        {
            message = "Dreadful...";
        }
        return message;
    }

    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time; // get current time
        print(waitTime + " seconds.");
        roundStarted = true;
    }


}
