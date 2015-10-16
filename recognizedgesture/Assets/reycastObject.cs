using UnityEngine;
using System.Collections;

public class reycastObject : MonoBehaviour {
    public GameObject hitPoint;
    float distance;
    public GameObject draw;
    public void checkPoints(int reyCount)
    {
        distance = 0;
        float chAngl=0;
        for (int i=0;i<reyCount;i++)
        {
            chAngl += 360 / (reyCount - 1);
            RaycastHit2D hit6 = Physics2D.Raycast(Vector2.zero, transform.up);
            distance += CheckDistance(new Vector2(hit6.point.x * 1.1f, hit6.point.y * 1.1f), transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, chAngl), 1);
        }
        
        print(distance / (reyCount));
        if (distance / (reyCount ) > 0.15f)
        {
            notWin();
        }
        else
        {
            Win();
        }
    }

    float CheckDistance(Vector2 hintpos, Vector2 dir)
    {
        print(hintpos);
        //Instantiate(hitPoint, hintpos, Quaternion.identity);
        RaycastHit2D hit = Physics2D.Raycast(hintpos, dir);
        //Instantiate(hitPoint, hit.point, Quaternion.identity);
        //print(hit.collider.name);
        return hit.distance;
    }

    void notWin()
    {
        EdgeCollider2D drawColl =draw.gameObject.GetComponent<EdgeCollider2D>();
        Destroy(drawColl);
    }

    void Win()
    {
        if (PlayerPrefs.HasKey("KolFigure"))
        {
            int kol = PlayerPrefs.GetInt("KolFigure");
            kol += 1;
            PlayerPrefs.SetInt("KolFigure", kol);
        }
        else
        {
            PlayerPrefs.SetInt("KolFigure", 1);
        }
        Application.LoadLevel("Game");
    }
}
