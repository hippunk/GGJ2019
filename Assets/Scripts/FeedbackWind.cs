using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackWind : MonoBehaviour
{
    public WindForce windForce;
    public float angle;
    public float lenght;
    RectTransform rectTransform;
    public Vector3 debugContent;
    public Vector2 debugCercle;
    public float circleLenght;
    public float squareLenght;
    public float tana;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3(windForce.force.x,0, windForce.force.z);
        angle = Mathf.Atan2(force.z, force.x);

        squareLenght = (force / GameObject.Find("WindManager").GetComponent<WindController>().speedThreshold).magnitude;

        
        lenght = squareLenght * 80;

        rectTransform.sizeDelta = new Vector2(5, lenght);
        rectTransform.rotation = Quaternion.Euler(0,0,(angle * 180 / Mathf.PI )- 90);
    }
}
