using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonbasket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y + 0.1), gameObject.transform.position.z);
    }
}
