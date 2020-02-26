using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TextChanger : MonoBehaviour
{
    TMPro.TextMeshProUGUI tm;
    KeyStrokesToString kayStrokesToString;
    int counter = 0;
    string typed_text = "";
    bool cursor = false;
    bool upper = false;

    // Start is called before the first frame update
    void Start()
    {
        
        tm = GetComponent<TMPro.TextMeshProUGUI>();
        kayStrokesToString = new KeyStrokesToString();
    }

    string process()
    {
        
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            upper = !upper;
        }

        
        
        typed_text = kayStrokesToString.process(typed_text,Input.GetKeyDown, upper);
        return typed_text;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            typed_text = process();
        }

        if (counter % 50 == 0)
        {
            cursor = !cursor;
        }
        
        
        if(cursor)
        {
            tm.SetText(typed_text);
        }
        else
        {
            tm.SetText(typed_text + "#");
        }
        
        counter += 1;
        
    }
}
