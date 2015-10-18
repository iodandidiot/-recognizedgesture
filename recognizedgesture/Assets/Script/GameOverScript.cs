using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    public Text Max;
    public Text Last;
	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.HasKey("MaxKolFigure"))
        {
            if (PlayerPrefs.GetInt("MaxKolFigure")<PlayerPrefs.GetInt("KolFigure"))
            {
                PlayerPrefs.SetInt("MaxKolFigure", PlayerPrefs.GetInt("KolFigure"));               
            }
            Max.text = string.Format("Максимальный результат {0}", PlayerPrefs.GetInt("MaxKolFigure"));
        }
        else
        {
            Max.text = string.Format("Максимальный результат  {0}", PlayerPrefs.GetInt("KolFigure"));
            PlayerPrefs.SetInt("MaxKolFigure", PlayerPrefs.GetInt("KolFigure")); 
        }
            Last.text = string.Format("Прошлый результат          {0}", PlayerPrefs.GetInt("KolFigure"));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
