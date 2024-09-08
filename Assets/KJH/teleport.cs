using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject player;
    //µµÂø ÁöÁ¡
    public GameObject end;
    public GameObject ui;

    public bool isTeleport;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTeleport)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
               
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
