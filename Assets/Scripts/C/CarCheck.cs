using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCheck : MonoBehaviour
{
    public List<PathPoint> path;
    public float speed;
    public int current_point = 0;
    [Range(0, 1)]
    public float t = 0;

    public Transform car;
    public bool is_car;
    public bool drive;

    private void OnTriggerEnter(Collider other)
    {
        is_car = true;
    }

    private void OnTriggerExit(Collider other)
    {
        is_car = false;
    }

    public void Transfort_Move()
    {
        if (current_point != path.Count - 1)
        {
            if (path[current_point].is_curve) { Curve_Movement(path[current_point], path[current_point + 1]); }
            else { Straight_Movement(path[current_point], path[current_point + 1]); }
        }
    }

    void Curve_Movement(PathPoint point1, PathPoint point2)
    {
        Vector3 p1 = point1.position;
        Vector3 p2 = point2.position;
        Vector3 p3 = point1.curve_point.transform.position;
        if (t >= 1) { t = 0; }
        StartCoroutine(Curve_Move(point1, point2, p3));
    }

    IEnumerator Curve_Move(PathPoint p1, PathPoint p2, Vector3 p3)
    {
        Vector3 p4 = Vector3.Lerp(p1.position, p3, t);
        Vector3 p5 = Vector3.Lerp(p3, p2.position, t);
        car.transform.position = Vector3.Lerp(p4, p5, t);

        Vector3 p1_rotate = new Vector3(p1.transform.eulerAngles.x, p1.transform.eulerAngles.y, p1.transform.eulerAngles.z);
        Vector3 p2_rotate = new Vector3(p2.transform.eulerAngles.x, p2.transform.eulerAngles.y, p2.transform.eulerAngles.z);
        car.transform.eulerAngles = Vector3.Lerp(p1_rotate, p2_rotate, t);

        yield return new WaitForSeconds(speed);
        if (t < 1)
        {
            StartCoroutine(Curve_Move(p1, p2, p3));
            t += speed;
        }
        else
        {
            current_point++;
            if (current_point != path.Count - 1)
                Transfort_Move();
            else {  }
        }
    }

    void Straight_Movement(PathPoint point1, PathPoint point2)
    {
        if (t >= 1) { t = 0; }
        StartCoroutine(Straight_Move(point1, point2));
    }

    IEnumerator Straight_Move(PathPoint p1, PathPoint p2)
    {
        car.transform.position = Vector3.Lerp(p1.position, p2.position, t);
        Vector3 p1_rotate = new Vector3(p1.transform.eulerAngles.x, p1.transform.eulerAngles.y, p1.transform.eulerAngles.z);
        Vector3 p2_rotate = new Vector3(p2.transform.eulerAngles.x, p2.transform.eulerAngles.y, p2.transform.eulerAngles.z);
        car.transform.eulerAngles = Vector3.Lerp(p1_rotate, p2_rotate, t * 5);
        yield return new WaitForSeconds(speed);
        if (t < 1)
        {
            StartCoroutine(Straight_Move(p1, p2));
            t += speed;
        }
        else
        {
            current_point++;
            if (current_point != path.Count - 1)
                Transfort_Move();
            else { }
        }
    }

    void OnDrawGizmosSelected()
    {
        foreach (var v in path)
        {
            if (v == path[0]) { Gizmos.color = Color.red; }
            else if (v == path[path.Count - 1]) { Gizmos.color = Color.blue; }
            else { Gizmos.color = Color.gray; }
            Gizmos.DrawCube(v.position, v.transform.localScale * .5f);

            Gizmos.color = Color.yellow;
            if (v.is_curve) { Gizmos.DrawCube(v.curve_point.transform.position, v.transform.localScale * 0.3f); }
        }
    }
}
