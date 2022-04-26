using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Transform myLimbTransform;
    public float pos;

    void OnMouseDown()
    {
        pos = this.transform.localPosition.z;
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
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
    private void OnMouseUp()
    {
        this.transform.localPosition = new Vector3(myLimbTransform.transform.position.x, myLimbTransform.transform.position.y, pos);
    }



}