using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClickManager : MonoBehaviour
{
    private RaycastHit2D hit;
    private GameObject selectedTarget;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                GameObject target = hit.collider.gameObject;
                Debug.Log(target);

                //N?u (target.CompareTag("Attacker") || target.CompareTag("Defender")) thì m?ii x? lý( cái này sau ae code hoàn ch?nh b? sung sau )
                // Ki?m tra n?u ??i t??ng ?ã ???c ch?n tr??c ?ó và không ph?i là ??i t??ng hi?n t?i
                if (selectedTarget != null && selectedTarget != target) 
                {
                    // ?n thanh máu c?a ??i t??ng tr??c ?ó
                    HideHealthBar(selectedTarget); 
                }
                // L?u ??i t??ng ???c ch?n
                selectedTarget = target;
                // Hi?n th? thanh máu c?a ??i t??ng hi?n t?i
                ShowHealthBar(selectedTarget); 
            }
        }
    }
    void ShowHealthBar(GameObject target)
    {
        GameObject childGameObject = getGameChildObject(target);
        Canvas canvas = childGameObject.GetComponent<Canvas>();
        canvas.enabled = true;
    }

    void HideHealthBar(GameObject target)
    {
        GameObject childGameObject = getGameChildObject(target); 
        Canvas canvas = childGameObject.GetComponent<Canvas>();
        canvas.enabled = false;
    }
    GameObject getGameChildObject(GameObject target)
    {
        // l?y Transform c?a ??i t??ng cha
        Transform parentTransform = target.transform; 
        Transform childTransform = parentTransform.Find("Canvas");
        GameObject childGameObject = childTransform.gameObject;
        return childGameObject;
    }
}
