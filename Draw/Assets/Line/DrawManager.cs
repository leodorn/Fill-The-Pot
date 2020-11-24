using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawManager : MonoBehaviour
{

    public GameObject linePrefab;
    public GameObject currentLine;

    public EdgeCollider2D edgeCollider;
    public LineRenderer lineRenderer;
    public List<Vector2> fingerPosition;
    public float amountLine;
    public bool erase;
    [SerializeField] float eraseRange;
    Slider slider;
    [SerializeField]
    Color colorRed, colorBlack;
    public static DrawManager instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        slider = GameObject.Find("LineBar").GetComponent<Slider>();
        slider.maxValue = amountLine;
        slider.minValue = 0;
        slider.value = amountLine;


    }
    private void Update()
    {
        if(!erase)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(amountLine>0)
                {
                    CreateLine();
                }
                
            }
            if (Input.GetMouseButton(0))
            {
                if(amountLine>0)
                {
                    
                    Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (Vector2.Distance(tempFingerPos, fingerPosition[fingerPosition.Count - 1]) > .1f)
                    {
                        
                        SliderManager.instance.SetSliderLine(amountLine);
                        UpdateLine(tempFingerPos);
                    }
                }
                
            }
        }
        if(erase)
        {
            if(Input.GetMouseButton(0))
            {
                Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                EraseLine(tempFingerPos);
            }
        }
        
    }


    private void OnDrawGizmos()
    {
        if(erase)
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(tempFingerPos, eraseRange);
        }
    }
    private void EraseLine(Vector2 tempFingerPos)
    {
        Collider2D[] listCollider = Physics2D.OverlapCircleAll(tempFingerPos, eraseRange);
        foreach(Collider2D collider in listCollider)
        {
            if(collider.CompareTag("Line"))
            {
                Destroy(collider.gameObject);
            }
            
        }
    }

    private void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        fingerPosition.Clear();
        fingerPosition.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Vector2 pos2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos2.x += 0.01f;
        fingerPosition.Add(pos2);
        lineRenderer.SetPosition(0, fingerPosition[0]);
        lineRenderer.SetPosition(1, fingerPosition[1]);
        edgeCollider.points = fingerPosition.ToArray();
    }

    private void UpdateLine(Vector2 newFingerPos)
    {
        
        fingerPosition.Add(newFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount -1  , newFingerPos);
        edgeCollider.points = fingerPosition.ToArray();
        Debug.Log(Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), lineRenderer.GetPosition(lineRenderer.positionCount - 2)));
        amountLine -= Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), lineRenderer.GetPosition(lineRenderer.positionCount - 2));
    }

    public void ChangeMode()
    {
        erase = !erase;
    }





    //[SerializeField] GameObject pixel;

    //private void Start()
    //{
    //    StartCoroutine(draw());
    //}


    //private IEnumerator draw()
    //{
    //    Vector2 position = Input.mousePosition;
    //    position = Camera.main.ScreenToWorldPoint(position);
    //    if (Input.GetMouseButton(0))
    //    {
    //        Instantiate(pixel, position, Quaternion.identity);
    //    }
    //    yield return new WaitForSeconds(0.1f);
    //    StartCoroutine(draw());
    //}

   
}
