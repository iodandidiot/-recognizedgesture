using UnityEngine;
using System.Collections;

public class Start : MonoBehaviour {

    public void startGame()
    {
        PlayerPrefs.SetInt("KolFigure", 0);
        Application.LoadLevel("Game");
    }
}
