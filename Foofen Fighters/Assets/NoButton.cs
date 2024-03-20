using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoButton : MonoBehaviour
{

    private Button button;
   
    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(deactivateCanvas);
    }

        void deactivateCanvas()
        {
            transform.parent.gameObject.SetActive(false);
        }
    
}
