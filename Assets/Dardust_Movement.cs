using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dardust_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("w")){
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10, 0);
      } 
    }
}