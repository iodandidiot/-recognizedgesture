using UnityEngine;
using System.Collections;

public class Template : MonoBehaviour
{
    LineRenderer line;
    PolygonCollider2D coll;
    Vector2[] position;
    public GameObject checkSprite;
    Vector2 centrMass;
    Vector2 poligonCentreMass;
    Rigidbody2D rgbody;
    // Use this for initialization
    void Start()
    {
        //line = transform.GetComponent<LineRenderer>();
        //line.SetVertexCount(5);
        //line.SetPosition(0, new Vector3(-1, 1, 0));
        //line.SetPosition(1, new Vector3(1, 1, 0));
        //line.SetPosition(2, new Vector3(1, -1, 0));
        //line.SetPosition(3, new Vector3(-1, -1, 0));
        //line.SetPosition(4, new Vector3(-1, 1, 0));        
        //position = new Vector2[10];
        //position[0] = new Vector2(-0.7f, 0.7f);
        //position[1] = new Vector2(0.7f, 0.7f);
        //position[2] = new Vector2(0.7f, -0.7f);
        //position[3] = new Vector2(-0.7f, -0.7f);
        //position[4] = new Vector2(-0.7f, 0.7f);
        //position[5] = new Vector2(-1.3f, 1.3f);
        //position[6] = new Vector2(1.3f, 1.3f);
        //position[7] = new Vector2(1.3f, -1.3f);
        //position[8] = new Vector2(-1.3f, -1.3f);
        //position[9] = new Vector2(-1.3f, 1.3f);
        //coll = gameObject.AddComponent<PolygonCollider2D>();
        //coll.SetPath(0, position);        
        //centrMass = coll.bounds.center;
        startFigur(5);
    }

    // Update is called once per frame
    void Update()
    {
        //print(coll.bounds);
    }


    public void checkPoligon(Vector2[] Array)//находим расстояние от начальной точки и сдвигаем весь полигон на это расстояние
    {
        float checkPosX = position[0].x - Array[0].x;
        float checkPosY = position[0].y - Array[0].y;
        PolygonCollider2D cSC = checkSprite.gameObject.AddComponent<PolygonCollider2D>();
        cSC.SetPath(0, Array);
        poligonCentreMass = cSC.bounds.center;
        Vector2 chengePos=poligonCentreMass - centrMass;
        print(cSC.bounds.size);
        
        for (int i = 0; i < Array.Length; i++)
        {
            Array[i] -= chengePos;
        }

        cSC.SetPath(0, Array);
        checkSprite.gameObject.transform.localScale = new Vector2((coll.bounds.size.x / cSC.bounds.size.x+coll.bounds.size.y / cSC.bounds.size.y)/2,
        (coll.bounds.size.x / cSC.bounds.size.x+coll.bounds.size.y / cSC.bounds.size.y)/2);
        print(coll.bounds.size);
        print(cSC.bounds.size);
        //checkPoints(Array.Length);

        int count = 0;
        for (int i = 0; i < Array.Length; i++)
        {
            if (coll.OverlapPoint(Array[i]))
            {
                //print(Array[i]);
                count += 1;
            }
        }
        print(count);
        

    }


    void checkPoints(int reyCount)
    {
        float _x=0;
        float _y=0;
        float Angle = 360 * Mathf.Deg2Rad;
        for (int i = 0; i < reyCount; i++)
        {
            _x = Mathf.Cos(Angle / reyCount * i)*10;
            _y = Mathf.Cos(Angle / reyCount * i)*10;
            print(new Vector2(_x, _y));
            RaycastHit2D hit = Physics2D.Raycast(centrMass, new Vector2(_x, _y));
            print(hit.collider.name);
            CheckDistance(hit.point, _x, _y);
        }
    }

    float CheckDistance(Vector2 hintpos,float _x,float _y)
    {
        RaycastHit2D hit = Physics2D.Raycast(centrMass, new Vector2(_x, _y));
        print(hit.collider.name);
        return hit.distance;
    }
    void startFigur(int kolStor)
    {
        float Angle=360;
        Angle = Angle * Mathf.Deg2Rad;
        float checkAngle=Angle/kolStor;
        //PolygonCollider2D poligon = gameObject.AddComponent<PolygonCollider2D>();
        Vector2 [] poligonPoints=new Vector2[kolStor+1];
        line = transform.GetComponent<LineRenderer>();
        line.SetVertexCount(kolStor+1);
        for (int i = 0; i < kolStor; i++)
        {
            poligonPoints[i] = new Vector2(Mathf.Cos(checkAngle * i), Mathf.Sin(checkAngle * i));
            line.SetPosition(i, new Vector3(Mathf.Cos(checkAngle * i), Mathf.Sin(checkAngle * i), 0));
        }

        line.SetPosition(kolStor,poligonPoints[0]);

        
    }
}