using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlideBar : MonoBehaviour
{
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Camera main = Camera.main;
        Vector3 slidePos = main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 temPos = transform.position;

        slidePos.x = Mathf.Clamp(slidePos.x, -1.77f, 1.77f);
        Debug.Log("It is working");

        temPos.x = slidePos.x;
        transform.position = temPos;
    }

    public IEnumerator resetSlidePos()
    {
        yield return new WaitForSeconds(3.4f);
        transform.position = _initialPosition;
    }


}
