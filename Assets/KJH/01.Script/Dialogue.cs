using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private NPCText dialogSystem01;
    public GameObject ui;

    public bool isTeleport;
    void Start()
    {
        
    }

    void Update()
    {
        if (isTeleport)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
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
