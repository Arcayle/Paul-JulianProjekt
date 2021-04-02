using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public nodeID nodeID_script;
    private GameObject mainscript;
    // Start is called before the first frame update
    void Start()
    {
        mainscript= GameObject.FindGameObjectsWithTag("mainscript")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
                var obj = hit.transform;
                nodeID_script = obj.GetComponent<nodeID>();
                
                if (mainscript.GetComponent<GraphComponents>().validClick(nodeID_script.ID)==true)
                {
                    
                    mainscript.GetComponent<GraphComponents>().moveCam();
                    
                }
              
                else { Debug.Log("Invalid Target"); }
                Debug.Log(nodeID_script.ID);
            }
        }
    }
}
