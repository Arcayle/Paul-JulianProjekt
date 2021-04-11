using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scenemanager : MonoBehaviour
{
    float i = 0;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        i += Time.deltaTime;
        if (i > 1000000)
        {
            i = 0;
            SceneManager.LoadScene("1" ,LoadSceneMode.Single);
        }
    }
}
