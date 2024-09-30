using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBall : MonoBehaviour
    ,IPointerDownHandler
    ,IDragHandler
    ,IPointerUpHandler
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float power;
    private Rigidbody2D _rigid;


    private Vector2 startPos;
    private Vector2 finishPos;
    private Vector2 fireAngle;
    private float fireVelocity;

    private bool isDraging;
    private void Awake()
    {
        _rigid = ball.GetComponent<Rigidbody2D>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;
        finishPos = Vector2.zero;
        startPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Input.mousePosition.z));
        print("start:"+startPos);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDraging)
        {
            finishPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Input.mousePosition.z));
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
        fireAngle = (finishPos - startPos).normalized;
        fireVelocity = Vector2.Distance(startPos,finishPos) * power;
        print("velocity:"+fireVelocity+",angle:"+fireAngle);
        _rigid.AddForce(-fireAngle * fireVelocity);
    }
}
