using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TranslateToMouse : MonoBehaviour
{
    RectTransform rect;
    private void Start()
    {
        rect= GetComponent<RectTransform>();
    }
    public void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, 0);
        rect.position = pos;
    }
}
