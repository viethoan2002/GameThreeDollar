using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Camera cam;

    public Ball ball;
    public Trajectory trajectory;
    GameObject barrel;
    [SerializeField] float PushForce = 4f;

    bool isDragging;


    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;

    private void Start()
    {
        cam = Camera.main;
        barrel = GameObject.FindWithTag("barrel");
    }

    private void Update()
    {
        Vector2 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging)
        {
            OnDrag();
        }
    }


    #region Drag

    private void OnDragStart()
    {
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    private void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = distance * direction * PushForce;

        trajectory.UpdateDots(ball.pos, force);
    }

    private void OnDragEnd()
    {
        barrel.GetComponent<BarrelEkey>().endControll();
        ball.Push(force);
        trajectory.Hide();
    }

    #endregion
}
