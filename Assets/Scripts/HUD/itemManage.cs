using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemManage : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI itemText;
    

    public int itemsTaken;
    private int maxItems;
    public bool allitemsTaken;

    void Start()
    {

        itemText = GetComponent<TextMeshProUGUI>();
        allitemsTaken = false;
        itemsTaken = 0;
        maxItems = 5;
        updateText();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText() 
    {
        itemText.text = itemsTaken + " / " + maxItems;
        if (itemsTaken == maxItems) { allitemsTaken = true; }
    }

   
}
