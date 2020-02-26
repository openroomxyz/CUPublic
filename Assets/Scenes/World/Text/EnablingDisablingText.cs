using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablingDisablingText : MonoBehaviour
{
    public GameObject go;

    bool showIt = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2))
        {
            showIt = !showIt;
            Debug.Log("showIt : " + showIt);
        }

        if(go != null)
        {
            if(go.activeSelf != showIt)
            {
                go.SetActive(showIt);
            }
            
        }
    }
}
