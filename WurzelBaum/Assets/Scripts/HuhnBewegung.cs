using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HuhnBewegung : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public float maxspeed, speed;
    public int direction, direction_y;
    private float loadposition_y;
    private float new_y, old_y, x,y;
    List<Vector2> screen_dim;
    private float line_of_flight, y_flight;
    void Start()
    {
        line_of_flight = Random.Range(-20, 11) / 5.0f;
        if (line_of_flight < 0)
        {
            line_of_flight = 0;
        }
        float loadposition_x = transform.position.x;
        loadposition_y = transform.position.y;
        new_y = transform.position.y;
        old_y = transform.position.y;
        direction_y = 1;
        maxspeed = 1;
        speed = maxspeed;
        screen_dim = GameObject.FindGameObjectsWithTag("mainscript_huhn")[0].GetComponent<hohrmuhn>().return_screen();
        if ((screen_dim[1].x - screen_dim[0].x)*0.5>loadposition_x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
    }
    // Update is called once per frame
    void Update()
    {
        x += maxspeed * Time.deltaTime*6f;
        if (x>=System.Math.PI)
        {
            old_y = new_y;
            x = 0;
            new_y = loadposition_y+Random.Range(0, 101) / 100.0f * 0.1f * (screen_dim[1].y - screen_dim[0].y);
        }
       
        if (System.Math.Abs(old_y-transform.position.y)> System.Math.Abs(new_y - transform.position.y))
        {
            y= 0.5f * ((float)System.Math.Sin(x + System.Math.PI / 2.0f) + 1) * (old_y-new_y) +new_y;
        }
        else 
        {
            y = 0.5f * ((float)System.Math.Sin(x + System.Math.PI / 2.0f) + 1) * (old_y - new_y) + new_y;
        }
        y_flight += line_of_flight*Time.deltaTime;
        transform.position = new Vector3(transform.position.x+direction * maxspeed*Time.deltaTime,loadposition_y+y+y_flight, 0);
        if (transform.position.x < screen_dim[0].x | transform.position.x > screen_dim[1].x)
        {
            Destroy(this.gameObject);
        }
    }
}
