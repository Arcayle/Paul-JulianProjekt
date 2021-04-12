using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class hohrmuhn : MonoBehaviour
{
    public InputSetting myinput;
    public GameObject Huhn5g, Huhn10g, Huhn25g;
    public Camera camera;
    private int ammo, maxammo;
    private float reloading,time,  timehuhn;
    public float reloadtime, timetilspawn;
    private bool loadactive;
    private int score;
    public int prob_5g, prob_10g, prob_25g;
    public Vector2 screen_lower_left, screen_upper_right;
    public Text scoretext, timetext, ammotext;
    public int cam_direction;
    public Vector3 campos;
    public int cam_speed;
    public void reload()
    {
        if (loadactive == false)
        {
            loadactive = true;
            ammotext.text = System.Convert.ToString(ammo);

        }

    }
    public void schießnicht()
    {
        Debug.Log("schießnich");
    }
    private void Awake()
    {
        myinput = new InputSetting();
    }
    private void OnEnable()
    {
        myinput.Moorhuhn.Enable();
        myinput.Moorhuhn.Ballern.Enable();
        myinput.Moorhuhn.getMouse.Enable();


    }

    private void OnDisable()
    {
        myinput.Moorhuhn.Disable();
        myinput.Moorhuhn.Ballern.Disable();
        myinput.Moorhuhn.getMouse.Disable();


    }

    public void ballern(InputAction.CallbackContext context)
    {   
        if (context.performed)
        {
            if (loadactive == false && ammo > 0)
            {
                ammo += -1;

                RaycastHit[] hits;

                var mouseposition = Mouse.current.position.ReadValue();//myinput.Moorhuhn.getMouse.ReadValue<Vector2>();
                Ray ray = camera.ScreenPointToRay(mouseposition);
                /*
                hits = Physics.RaycastAll(ray, 100.0F);
                
                for (int i = 0; i < hits.Length; i++)
                {
                    
                    RaycastHit hitneu = hits[i];
                    
                    var col = hitneu.collider;
                    SpriteRenderer rend = hitneu.transform.GetComponent<SpriteRenderer>();

                    Texture2D tex = rend.sprite.texture as Texture2D;

                    if (tex != null)
                    {
                        var xInTex = (int)(hitneu.textureCoord.x * tex.width);
                        var yInTex = (int)(hitneu.textureCoord.y * tex.height);
                        var pix = tex.GetPixel(xInTex, yInTex);
                        if (pix.a > 0)
                        {
                            //Debug.Log("You hit: " + col.name + " position " + h.textureCoord.x + " , " + h.textureCoord.y);
                            Debug.Log("neuesRaycastetest");

                        }
                    }
                    else
                    {
                        Debug.Log("ich bin eine null");
                    }
                    
                }
                */
                Debug.Log(System.Convert.ToString(mouseposition));


                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("PÄNG!");
                    var obj = hit.transform;
                    if (obj.gameObject.tag == "5g") { Destroy(obj.gameObject); score += 5; }
                    else if (obj.gameObject.tag == "10g") { Destroy(obj.gameObject); score += 10; }
                    else if (obj.gameObject.tag == "25g") { Destroy(obj.gameObject); score += 25; }

                }
                scoretext.text = System.Convert.ToString(score);
                ammotext.text = System.Convert.ToString(ammo);

                Debug.Log("PENG!");

            }
            else
            {
                Debug.Log("Keine Munition..");
            }
        }
        
    }
    public List<Vector2> return_screen()
    {
        List<Vector2> list = new List<Vector2>();
        list.Add(screen_lower_left);
        list.Add(screen_upper_right);
        return list;
    }
    private void spawn_bird()
    {
        int Coin = Random.Range(0, 1000);
        if (Coin < prob_5g)
        {
            float x;
            float y = screen_lower_left[1]+(screen_upper_right[1]-screen_lower_left[1])*(0.4f + Random.Range(-20, 21) / 100.0f);
            if (Random.Range(0, 2) == 0)
            {
                x = screen_lower_left[0];
            }
            else
            {
                x = screen_upper_right[0];
            }
            Instantiate(Huhn5g, new Vector3(x, y, 0), Quaternion.identity);
        }
        else if (Coin < prob_5g + prob_10g)
        {
            float x;
            float y = screen_lower_left[1] + (screen_upper_right[1] - screen_lower_left[1]) * (0.45f + Random.Range(-20, 21) / 100.0f);
            if (Random.Range(0, 2) == 0)
            {
                x = screen_lower_left[0];
            }
            else
            {
                x = screen_upper_right[0];
            }
            Instantiate(Huhn10g, new Vector3(x, y, 0), Quaternion.identity);
        }
        else if (Coin <= prob_5g + prob_10g+ prob_25g)
        {
            float x;
            float y = screen_lower_left[1] + (screen_upper_right[1] - screen_lower_left[1]) * (0.8f + Random.Range(-20, 21) / 100.0f);
            if (Random.Range(0, 2) == 0)
            {
                x = screen_lower_left[0];
            }
            else
            {
                x = screen_upper_right[0];
            }
            Instantiate(Huhn25g, new Vector3(x, y, 0), Quaternion.identity);
        }
        else
        {
            Debug.Log("Bird.exe not found");
        }
        timetilspawn = Random.Range(30, 91) / 30.0f;
    }
    private void FixedUpdate()
    {
        moveCam();
    }
    private void moveCam()
    {
        var mouseposition = Mouse.current.position.ReadValue();
        if (mouseposition[0] < 0.05f * Screen.width)
        {
            cam_direction = -1;
        }
        else if (mouseposition[0] > 0.95f * Screen.width)
        {
            cam_direction = 1;
        }
        else
        {
            cam_direction = 0;
        }
        campos[0] = cam_speed * Time.deltaTime * cam_direction + camera.transform.position.x;
        if (campos[0] <= screen_lower_left.x)
        {
            campos[0] = screen_lower_left.x;
            camera.transform.position = campos;
        }
        else if (campos[0] >= screen_upper_right.x)
        {
            campos[0] = screen_upper_right.x;
            camera.transform.position = campos;
        }
        else { camera.transform.position = campos; }
    }
    void Start()
    {
        cam_speed = 6;
        campos = new Vector3(13,16,-22);
        myinput = new InputSetting();
        PlayerPrefs.SetInt("maxammo", 6);
        PlayerPrefs.SetFloat("reloadtime", 1);
        timetilspawn = 0;
        loadactive = false;
        reloadtime = PlayerPrefs.GetFloat("reloadtime");
        maxammo = PlayerPrefs.GetInt("maxammo");
        ammo = maxammo;
        time = 0;
        score = 0;
        prob_10g = 250;
        prob_25g = 150;
        prob_5g = 600;
    }

    // Update is called once per frame
    void Update()
    {   time += Time.deltaTime;
        timehuhn += Time.deltaTime;
        int timedisplay = (int)time;
        timetext.text = System.Convert.ToString(timedisplay);

        if (reloading >= reloadtime)
        {
            loadactive = false;
            ammo = maxammo;
            reloading = 0;
            ammotext.text = System.Convert.ToString(ammo);

        }
        if (loadactive)
        {
            reloading += Time.deltaTime;
        }
        if (timetilspawn <= timehuhn)
        {
            timehuhn = 0;
            spawn_bird();
        }
        
        
        
    }
}
