using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaOBject : MonoBehaviour
{
    public Image sprite;
    // Start is called before the first frame update
    public void OnEnable()
    {
  

            sprite.alphaHitTestMinimumThreshold = 0.0001f;
       
    }
}
