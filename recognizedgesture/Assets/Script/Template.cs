using UnityEngine;
using System.Collections;

public class Template : MonoBehaviour
{
    LineRenderer line;//визуализация заданного полигона
    //PolygonCollider2D coll;//заданный полигон
    EdgeCollider2D coll;
    PolygonCollider2D cell;
    Vector2[] position;
    public GameObject checkSprite;
    Vector2 centrMass;
    Vector2 poligonCentreMass;
    Rigidbody2D rgbody;
    public int countPolig=3;
    public GameObject hitPoint;
    public GameObject reyObj;
    // Use this for initialization
    void Start()
    {        
        startFigur(countPolig);
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
        //PolygonCollider2D cSC = checkSprite.gameObject.AddComponent<PolygonCollider2D>();        
        //cSC.SetPath(0, Array);
        EdgeCollider2D cSC = checkSprite.gameObject.AddComponent<EdgeCollider2D>();
        cSC.points = Array;
        poligonCentreMass = cSC.bounds.center;
        print(poligonCentreMass);
        print(centrMass);
        Vector2 chengePos=poligonCentreMass - centrMass;        
        for (int i = 0; i < Array.Length; i++)
        {
            Array[i] -= chengePos;
        }

        //cSC.SetPath(0, Array);
        cSC.points = Array;
        checkSprite.gameObject.transform.localScale = new Vector2((coll.bounds.size.x / cSC.bounds.size.x+coll.bounds.size.y / cSC.bounds.size.y)/2,
        (coll.bounds.size.x / cSC.bounds.size.x+coll.bounds.size.y / cSC.bounds.size.y)/2);
        //checkPoints(Array.Length);
        reycastObject reyObjfunc = reyObj.GetComponent<reycastObject>();
        reyObjfunc.checkPoints(Array.Length);
        //int count = 0;
        //for (int i = 0; i < Array.Length; i++)
        //{
        //    if (cell.OverlapPoint(Array[i]))
        //    {
        //        //print(Array[i]);
        //        count += 1;
        //    }
        //}
        //print(count);
        

    }


    void checkPoints(int reyCount)
    {
        float _x = 0;
        float _y = 0;
        float Angle = 360 * Mathf.Deg2Rad;
        float distance = 0;
        //for (int i = 0; i < 3; i++)
        //{
        //    _x = Mathf.Cos(Angle / reyCount * i) * 10;
        //    _y = Mathf.Cos(Angle / reyCount * i) * 10;

        //    RaycastHit2D hit = Physics2D.Raycast(centrMass, Vector2.up + new Vector2(2000 * i, 2000 * i));
        //    distance += CheckDistance(new Vector2(hit.point.x * 1.1f, hit.point.y * 1.1f), _x, _y);
        //    RaycastHit2D hit2 = Physics2D.Raycast(centrMass, -Vector2.up - new Vector2(2000 * i, 2000 * i));
        //    distance += CheckDistance(new Vector2(hit.point.x * 1.1f, hit.point.y * 1.1f), _x, _y);


        //}
        //RaycastHit2D hit = Physics2D.Raycast(centrMass, Vector2.one);
        //distance += CheckDistance(new Vector2(hit.point.x * 1.1f, hit.point.y * 1.1f), Vector2.one);
        //RaycastHit2D hit2 = Physics2D.Raycast(centrMass, -Vector2.one);
        //distance += CheckDistance(new Vector2(hit2.point.x * 1.1f, hit2.point.y * 1.1f), -Vector2.one);
        //RaycastHit2D hit3 = Physics2D.Raycast(centrMass, Vector2.up);
        //distance += CheckDistance(new Vector2(hit3.point.x * 1.1f, hit3.point.y * 1.1f), Vector2.up);
        //RaycastHit2D hit4 = Physics2D.Raycast(centrMass, -Vector2.up);
        //distance += CheckDistance(new Vector2(hit3.point.x * 1.1f, hit4.point.y * 1.1f), -Vector2.up);
        //RaycastHit2D hit5 = Physics2D.Raycast(centrMass, Vector2.left);
        //distance += CheckDistance(new Vector2(hit5.point.x * 1.1f, hit5.point.y * 1.1f), Vector2.left);
        //RaycastHit2D hit6 = Physics2D.Raycast(centrMass, -Vector2.left);
        //distance += CheckDistance(new Vector2(hit6.point.x * 1.1f, hit6.point.y * 1.1f), -Vector2.left);
        print(distance / reyCount);
    }

    float CheckDistance(Vector2 hintpos, Vector2 dir)
    {
        print(hintpos);
        Instantiate(hitPoint, hintpos, Quaternion.identity);
        RaycastHit2D hit = Physics2D.Raycast(hintpos,dir);
        Instantiate(hitPoint, hit.point, Quaternion.identity);
        //print(hit.collider.name);
        return hit.distance;
    }
    void startFigur(int kolStor)
    {
        float _var=2f;
        float Angle=360;
        Angle = Angle * Mathf.Deg2Rad;
        float checkAngle=Angle/kolStor;
        //PolygonCollider2D poligon = gameObject.AddComponent<PolygonCollider2D>();
        position = new Vector2[kolStor + 1];
        line = transform.GetComponent<LineRenderer>();
        line.SetVertexCount(kolStor+1);
        for (int i = 0; i < kolStor+1; i++)
        {
            position[i] = new Vector2(Mathf.Cos(checkAngle * i - 30 * Mathf.Deg2Rad) * _var, Mathf.Sin(checkAngle * i - 30 * Mathf.Deg2Rad) * _var);
            line.SetPosition(i, new Vector3(Mathf.Cos(checkAngle * i - 30 * Mathf.Deg2Rad) * _var, Mathf.Sin(checkAngle * i - 30 * Mathf.Deg2Rad) * _var, 0));
        }

        line.SetPosition(kolStor, position[0]);
        //coll = gameObject.AddComponent<PolygonCollider2D>();
        //coll.SetPath(0, position);        
        //centrMass = coll.bounds.center;
        coll = gameObject.AddComponent<EdgeCollider2D>();
        coll.points = position;
        //addPoligon();
        
    }

    void addPoligon()
    {
        Vector2 [] poligonPosition=new Vector2[position.Length*2];
        float varCell=2f;

        for (int i = 0; i < position.Length; i++)
        {
            poligonPosition[i] = new Vector2(position[i].x * varCell, position[i].y*varCell);
            print(poligonPosition[i]);
            poligonPosition[poligonPosition.Length-i-1] = new Vector2(position[i].x/varCell, position[i].y/varCell);
            print(poligonPosition[poligonPosition.Length - i - 1]);            
        }
        cell = gameObject.AddComponent<PolygonCollider2D>();
        cell.SetPath(0, poligonPosition);        

    }

}