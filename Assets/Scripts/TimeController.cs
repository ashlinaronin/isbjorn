using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public static float gravity = -100;

    public struct RecordedData
    {
        Vector3 position;
        Vector3 velocity;
    }

    RecordedData[][] recordedData;

    TimeControlled[] timeObjects;


    private void Awake()
    {
        timeObjects = GameObject.FindObjectsOfType<TimeControlled>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pause = Input.GetKey(KeyCode.H);
        bool stepBack = Input.GetKey(KeyCode.J);
        bool stepForward = Input.GetKey(KeyCode.K);

        if (stepBack)
        {

        }
        else if (pause && stepForward)
        {

        }
        else if (!pause && !stepBack)
        {
            foreach (TimeControlled timeObject in timeObjects)
            {
                timeObject.TimeUpdate();
            }
        }
    }
}
