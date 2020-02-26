using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuardTargetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootEvent(Vector2 pos)
    {
        GetComponent<Compute>().ShootEvent(pos);
    }
}
