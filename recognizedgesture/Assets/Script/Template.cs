using UnityEngine;
using System.Collections;

public class Template : MonoBehaviour
{
    LineRenderer line;
    PolygonCollider2D coll;
    Vector2[] position;
    public GameObject checkSprite;
    Vector2 centrMass;
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
        position = new Vector2[10];
        position[0] = new Vector2(-1, 1);
        position[1] = new Vector2(1, 1);
        position[2] = new Vector2(1, -1);
        position[3] = new Vector2(-1, -1);
        position[4] = new Vector2(-1, 1);
        position[5] = new Vector2(-1.1f, 1.1f);
        position[6] = new Vector2(1.1f, 1.1f);
        position[7] = new Vector2(1.1f, -1.1f);
        position[8] = new Vector2(-1.1f, -1.1f);
        position[9] = new Vector2(-1.1f, 1.1f);
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
        //for (int i = 0; i < Array.Length; i++)
        //{
        //    Array[i].x += checkPosX-1;
        //    Array[i].y += checkPosY-1;
        //}
        cSC.SetPath(0, Array);
        //Rigidbody2D __spriteRigidbody = checkSprite.gameObject.AddComponent<Rigidbody2D>();
        //__spriteRigidbody.isKinematic = true;
        //__spriteRigidbody.centerOfMass = centrMass;
        Vector2 poligonCentreMass = cSC.bounds.center;
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
        int count = 0;
        for (int i = 0; i < Array.Length; i++)
        {
            if (coll.bounds.ClosestPoint(cSC.points[i]).x == cSC.points[i].x && coll.bounds.ClosestPoint(cSC.points[i]).y == cSC.points[i].y)
            {
                count += 1;
            }
        }
        print(count);
    }
}