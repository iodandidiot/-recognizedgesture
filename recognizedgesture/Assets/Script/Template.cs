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
        line = transform.GetComponent<LineRenderer>();
        line.SetVertexCount(5);
        line.SetPosition(0, new Vector3(-1, 1, 0));
        line.SetPosition(1, new Vector3(1, 1, 0));
        line.SetPosition(2, new Vector3(1, -1, 0));
        line.SetPosition(3, new Vector3(-1, -1, 0));
        line.SetPosition(4, new Vector3(-1, 1, 0));
        position = new Vector2[5];
        position[0] = new Vector2(-1, 1);
        position[1] = new Vector2(1, 1);
        position[2] = new Vector2(1, -1);
        position[3] = new Vector2(-1, -1);
        position[4] = new Vector2(-1, 1);
        coll = gameObject.AddComponent<PolygonCollider2D>();

        //ollgameObject.GetComponent<PolygonCollider2D>().SetPath(0, position);
        coll.SetPath(0, position);
        //Rigidbody2D __rigidbody = gameObject.AddComponent<Rigidbody2D>();
        //__rigidbody.isKinematic = true;
        //centrMass = __rigidbody.worldCenterOfMass;
        centrMass = coll.bounds.center;
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
        print(cSC.bounds.size);
        checkPoints(Array.Length);

        //int count = 0;
        //for (int i = 0; i < Array.Length; i++)
        //{
        //    if (coll.OverlapPoint(Array[i]))
        //    {
        //        count += 1;
        //    }
        //}
        //print(count);
        //cSC.isTrigger = true;
        //coll.isTrigger = true;
        //rgbody = gameObject.AddComponent<Rigidbody2D>();
        //rgbody.gravityScale = 0;
        //Rigidbody2D __rg2= cSC.gameObject.AddComponent<Rigidbody2D>();
        //__rg2.gravityScale = 0;

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
            RaycastHit2D hit = Physics2D.Raycast(poligonCentreMass,new Vector2(_x,_y));
            print(hit.collider.name);
        }
    }
}