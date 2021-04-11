using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class raycast : MonoBehaviour
{
    public nodeID nodeID_script;
    private GameObject mainscript;
    public InputSetting my_input;
    public 

    // Start is called before the first frame update
    void Start()
    {
        mainscript= GameObject.FindGameObjectsWithTag("mainscript")[0];
    }
     public void leftclick()
    {
        var mousepos = Mouse.current.position.ReadValue();
        Ray ray = GetComponent<Camera>().ScreenPointToRay(mousepos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // the object identified by hit.transform was clicked
            // do whatever you want
            var obj = hit.transform;
            Debug.Log("hi");
            nodeID_script = obj.GetComponent<nodeID>();

            if (mainscript.GetComponent<GraphComponents>().validClick(nodeID_script.ID) == true)
            {

                mainscript.GetComponent<GraphComponents>().moveCam();

            }

            else { Debug.Log("Invalid Target"); }
            Debug.Log(nodeID_script.ID);
        }
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
