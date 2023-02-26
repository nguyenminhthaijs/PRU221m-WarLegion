using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClickManager : MonoBehaviour
{
    private RaycastHit2D hit;
    private GameObject selectedTarget;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                GameObject target = hit.collider.gameObject;
                Debug.Log(target);

                //Neu (target.CompareTag("Attacker") || target.CompareTag("Defender")) thì moii xu lý( cái này sau ae code hoàn chinh bo sung sau )
                // Kiem tra neu ?oi t??ng ?a ?uoc ch?n tr??c ?ó và không phai là ?oi t??ng hi?n t?i
                if (selectedTarget != null && selectedTarget != target) 
                {
                    // An thanh máu cua doi tuong trc dó
                    HideHealthBar(selectedTarget); 
                }
                // Luu doi tuong duoc chon
                selectedTarget = target;
                // Hien thi thanh máu cua doi tuonng hien tai
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
        // lay Transform cua doi tuong cha
        Transform parentTransform = target.transform; 
        Transform childTransform = parentTransform.Find("Canvas");
        GameObject childGameObject = childTransform.gameObject;
        return childGameObject;
    }
}
