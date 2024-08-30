using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject player;
    //도착 지점
    public GameObject end;
    public GameObject ui;
    //파티클
    public ParticleSystem da;

    public bool isTeleport;
    // Start is called before the first frame update
    void Start()
    {
        da.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTeleport)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                da.Play();
               
                player.transform.position = end.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isTeleport = true;
           

        }
        
       

        if (collision.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTeleport = false;
        ui.SetActive(false);
    }
}
