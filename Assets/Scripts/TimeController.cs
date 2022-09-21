using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    // public static float gravity = -100;

    public struct RecordedData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 velocity;
    }

    RecordedData[,] recordedData;
    int recordMax = 100000;
    int recordCount;
    int recordIndex; 
    bool wasReplaying = false;

    TimeControlled[] timeObjects;


    private void Awake()
    {
        timeObjects = GameObject.FindObjectsOfType<TimeControlled>();
        recordedData = new RecordedData[timeObjects.Length, recordMax];
    }


    void Update()
    {
        bool pause = Input.GetKey(KeyCode.H);
        bool stepBack = Input.GetKey(KeyCode.J);
        bool stepForward = Input.GetKey(KeyCode.K);

        if (stepBack)
        {
            wasReplaying = true;


            // note: tutorial did this opposite; i modified to use early return
            if (recordIndex <= 0) return;

            recordIndex--;

            for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
            {
                TimeControlled timeObject = timeObjects[objectIndex];
                RecordedData data = recordedData[objectIndex, recordIndex];
                timeObject.transform.position = data.position;
                timeObject.transform.rotation = data.rotation;
                timeObject.velocity = data.velocity;
            }

        }
        else if (pause && stepForward)
        {
            wasReplaying = true;

            // same as above - tutorial did opposite, i used early return
            if (recordIndex >= recordCount - 1) return;

            recordIndex++;

            for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
            {
                TimeControlled timeObject = timeObjects[objectIndex];
                RecordedData data = recordedData[objectIndex, recordIndex];
                timeObject.transform.position = data.position;
                timeObject.transform.rotation = data.rotation;
                timeObject.velocity = data.velocity;
            }

        }

        // moving normally through time
        else if (!pause && !stepBack)
        {

            if (wasReplaying)
            {
                recordCount = recordIndex;
                wasReplaying = false;
            }            

            for (int objectIndex = 0; objectIndex < timeObjects.Length; objectIndex++)
            {
                TimeControlled timeObject = timeObjects[objectIndex];
                RecordedData data = new RecordedData();
                data.position = timeObject.transform.position;
                data.rotation = timeObject.transform.rotation;
                data.velocity = timeObject.velocity;
                recordedData[objectIndex, recordCount] = data;
            }
            recordCount++;
            recordIndex = recordCount;

            foreach (TimeControlled timeObject in timeObjects)
            {
                timeObject.TimeUpdate();
            }
        }
    }
}
