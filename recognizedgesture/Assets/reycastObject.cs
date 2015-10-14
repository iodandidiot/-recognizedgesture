using UnityEngine;
using System.Collections;

public class reycastObject : MonoBehaviour {
    public GameObject hitPoint;
    float distance;
    public void checkPoints(int reyCount)
    {   
        float chAngl=0;
        for (int i=0;i<reyCount/3;i++)
        {
            chAngl += 360 / (reyCount/3 - 1);
            RaycastHit2D hit6 = Physics2D.Raycast(Vector2.zero, transform.up);
            distance += CheckDistance(new Vector2(hit6.point.x * 1.1f, hit6.point.y * 1.1f), transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, chAngl), 1);
        }
        
        print(distance / reyCount);
    }

    float CheckDistance(Vector2 hintpos, Vector2 dir)
    {
        print(hintpos);
        Instantiate(hitPoint, hintpos, Quaternion.identity);
        RaycastHit2D hit = Physics2D.Raycast(hintpos, dir);
        Instantiate(hitPoint, hit.point, Quaternion.identity);
        //print(hit.collider.name);
        return hit.distance;
    }
}
