using UnityEngine;
using System.Collections;

public class TimerToDraw : MonoBehaviour {

    public GameObject[] allhitPoints;

	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
    void checkPointsForStart(int minusPoint)
    {
        allhitPoints=new GameObject[10 - minusPoint];
        for (int i = 0; i < 10 - minusPoint; i++)
        {

            Instantiate(allhitPoints[i], new Vector2(-6 + 2 * i, 4.5f), Quaternion.identity);
        }
    }
}
