using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerToDraw : MonoBehaviour {

    public GameObject pointList;
    public float Timer;

	// Use this for initialization
	void Start () 
    {
        startClock();
        if (Timer > PlayerPrefs.GetInt("KolFigure")) Timer -= PlayerPrefs.GetInt("KolFigure");
        else Timer = 1;
	}
	
	// Update is called once per frame
    void startClock()
    {
        StartCoroutine(checkPointsForStart());
    }
    IEnumerator checkPointsForStart()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(pointList, new Vector2(-6 + 1.3f * i, 4.5f), Quaternion.identity);
            yield return new WaitForSeconds(Timer);
        }
        
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Finish").Length == 10) Application.LoadLevel("EndGame");
    }
}
