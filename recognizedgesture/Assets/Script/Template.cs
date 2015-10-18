using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Template : MonoBehaviour
{
    LineRenderer line;//визуализация заданного полигона
    EdgeCollider2D coll;
    Vector2[] position;
    public GameObject checkSprite;
    Vector2 centrMass;
    Vector2 poligonCentreMass;
    Rigidbody2D rgbody;
    public int countPolig=3;
    public GameObject hitPoint;
    public GameObject reyObj;
    public float Timer; 
    private float TimerDown;
    public Text colText;
    // Use this for initialization
    void Start()
    {        
        startFigur(Random.Range(3,6),Random.Range(0,360));
        TimerDown = Timer;
    }

    public void checkPoligon(Vector2[] Array)//находим расстояние от начальной точки и сдвигаем весь полигон на это расстояние
    {
        float checkPosX = position[0].x - Array[0].x;
        float checkPosY = position[0].y - Array[0].y;
        EdgeCollider2D cSC = checkSprite.gameObject.AddComponent<EdgeCollider2D>();
        cSC.points = Array;
        poligonCentreMass = cSC.bounds.center;
        Vector2 chengePos = poligonCentreMass - Vector2.zero;
        for (int i = 0; i < Array.Length; i++)
        {
            Array[i] -= chengePos;
        }

        cSC.points = Array;
        checkSprite.gameObject.transform.localScale = new Vector2((coll.bounds.size.x / cSC.bounds.size.x+coll.bounds.size.y / cSC.bounds.size.y)/2,
        (coll.bounds.size.x / cSC.bounds.size.x+coll.bounds.size.y / cSC.bounds.size.y)/2);//подгоняем размер полигона в заданному
        reycastObject reyObjfunc = reyObj.GetComponent<reycastObject>();
        reyObjfunc.checkPoints(Array.Length);//сравнение полигонов
        

    }
    
    void startFigur(int kolStor,int chAngle)
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
            position[i] = new Vector2(Mathf.Cos(checkAngle * i - chAngle * Mathf.Deg2Rad) * _var, Mathf.Sin(checkAngle * i - chAngle * Mathf.Deg2Rad) * _var);
            line.SetPosition(i, new Vector3(Mathf.Cos(checkAngle * i - chAngle * Mathf.Deg2Rad) * _var, Mathf.Sin(checkAngle * i - chAngle * Mathf.Deg2Rad) * _var, 0));
        }

        line.SetPosition(kolStor, position[0]);
        coll = gameObject.AddComponent<EdgeCollider2D>();
        coll.points = position;

        
    }

}