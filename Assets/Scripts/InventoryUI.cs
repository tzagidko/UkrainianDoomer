using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Image myImg;
    void Start()
    {
        myImg=GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       myImg.sprite=Inventory.currentImg;
    }
}
