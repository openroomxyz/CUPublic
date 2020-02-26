using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject go;

    public Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if(Input.GetMouseButton(0))//if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;



            Ray ray = new Ray(pos.position, Vector3.Normalize(pos.position - transform.position));
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit :" + hit.transform.name);

                if (go != null)
                {
                    if((hit.transform.name == "A") || (hit.transform.name == "B") ||  (hit.transform.name == "C") || (hit.transform.name == "D") || (hit.transform.name == "E") || (hit.transform.name == "F"))
                    {
                        QuardTargetScript s = hit.transform.gameObject.GetComponent<QuardTargetScript>();//(hit.transform.gameObject as QuardTargetScript);
                        s.ShootEvent(hit.textureCoord);
                        //Instantiate(go, hit.point, Quaternion.identity);
                    }

                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        
    }
}
