using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointControl : MonoBehaviour
{
    public Transform myLimbTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {
        this.transform.position = new Vector3(myLimbTransform.transform.position.x, myLimbTransform.transform.position.y,this.transform.position.z);
    }
}
