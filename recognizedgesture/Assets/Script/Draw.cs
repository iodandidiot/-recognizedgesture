using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class Draw : MonoBehaviour
{

    private LineRenderer line;
    private bool isMousePressed;
    public List<Vector2> pointsList;
    private Vector2 mousePos;
    public GameObject template;
    public Image lose;
    public bool checkFigur = false;
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };

    void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(0);
        line.SetColors(Color.green, Color.green);
        line.useWorldSpace = true;
        isMousePressed = false;
        pointsList = new List<Vector2>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMousePressed = true;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            //line.SetColors(new Color(1, 0, 0, 0), new Color(0, 1, 0, 0.5f));
            line.SetColors(new Color(153, 153, 153, 0), new Color(0, 1, 0, 0.5f));
            lose.gameObject.SetActive(false);
            
        }
        if (Input.GetMouseButtonUp(0))
        {            
            line.SetColors(Color.red, Color.red);
            if (pointsList.Count > 25 && isMousePressed) AddPoligon();//если игрок отпустил кнопку мышки, и заданно нужное количество точек - начинаем проверку
            isMousePressed = false;
            checkFigur = true;
        }
        if (isMousePressed)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!pointsList.Contains(mousePos))
            {
                
                pointsList.Add(mousePos);//добавляем в массив точек точки считанные с положения курсора
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);//рисуем линии
            }
            if (isLineCollide())//если фигура замкнута - начинаем проверку
            {
                isMousePressed = false;
                line.SetColors(Color.red, Color.red);
                AddPoligon();
                checkFigur = true;
            }
        }
    }
    private bool isLineCollide ()
    {
        if (pointsList.Count < 2) return false;
        int TotalLines = (pointsList.Count - 1)/2;
        myLine[] lines = new myLine[TotalLines];
        if (TotalLines > 1) {
            for (int i=0; i<TotalLines; i++) {
                lines [i].StartPoint = (Vector3)pointsList [i];
                lines [i].EndPoint = (Vector3)pointsList [i + 1];
            }
        }
        for (int i=0; i<TotalLines-1; i++) {
            myLine currentLine;
            currentLine.StartPoint = (Vector3)pointsList [pointsList.Count - 2];
            currentLine.EndPoint = (Vector3)pointsList [pointsList.Count - 1];
            if (isLinesIntersect (lines [i], currentLine))
                return true;
        }
        return false;
    }

    private bool checkPoints (Vector3 pointA, Vector3 pointB)
    {
        return (pointA.x == pointB.x && pointA.y == pointB.y);
    }
    
    private bool isLinesIntersect (myLine L1, myLine L2)
    {
        if (checkPoints (L1.StartPoint, L2.StartPoint) ||
            checkPoints (L1.StartPoint, L2.EndPoint) ||
            checkPoints (L1.EndPoint, L2.StartPoint) ||
            checkPoints (L1.EndPoint, L2.EndPoint))
            return false;
        
        return((Mathf.Max (L1.StartPoint.x, L1.EndPoint.x) >= Mathf.Min (L2.StartPoint.x, L2.EndPoint.x)) &&
            (Mathf.Max (L2.StartPoint.x, L2.EndPoint.x) >= Mathf.Min (L1.StartPoint.x, L1.EndPoint.x)) &&
            (Mathf.Max (L1.StartPoint.y, L1.EndPoint.y) >= Mathf.Min (L2.StartPoint.y, L2.EndPoint.y)) &&
            (Mathf.Max (L2.StartPoint.y, L2.EndPoint.y) >= Mathf.Min (L1.StartPoint.y, L1.EndPoint.y))
         );
    }
    void AddPoligon()
    {
        Template goToPoligon = template.GetComponent<Template>();
        goToPoligon.checkPoligon(pointsList.ToArray());
    }
}
