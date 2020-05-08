using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickObjects : MonoBehaviour
{
    // Start is called before the first frame update
    itemManage itemSC;
    
    void Start()
    {
        itemSC = FindObjectOfType<itemManage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider item)
    {
        print("Te cogí");
        if (item.CompareTag("keyItem"))
        {
            itemSC.itemsTaken += 1;

            itemSC.updateText();

            //item.gameObject.SetActive(false);
            Destroy(item.transform.parent.gameObject);
        }
    }
}
