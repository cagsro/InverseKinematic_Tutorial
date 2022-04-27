using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Transform myLimbTransform;
    private Vector3 initPos;

    void OnMouseDown()
    {
        initPos = transform.localPosition;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //Debug.Log("Konum" + mZCoord);
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        //Debug.Log("Mouse Point" + mousePoint);
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Vector3 temp = transform.localPosition;
        temp = GetMouseAsWorldPoint() + mOffset;
        temp.z = initPos.z;
        transform.localPosition = temp;
    }
    private void OnMouseUp()
    {
        if (Vector3.Distance(transform.localPosition, initPos) < 0.02f) return;
        this.transform.position = new Vector3(myLimbTransform.transform.position.x, myLimbTransform.transform.position.y, transform.position.z);
    }
}