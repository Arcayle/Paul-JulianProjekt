using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeID : MonoBehaviour
{
    //public GraphComponents otherscript;
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
       ID= GameObject.FindGameObjectsWithTag("mainscript")[0].GetComponent<GraphComponents>().mymethod();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
