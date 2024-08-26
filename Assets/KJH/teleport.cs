using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject player;
    public GameObject end;
    public GameObject ui;
    public ParticleSystem da;
    // Start is called before the first frame update
    void Start()
    {
        da.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            da.Play();
            new WaitForSeconds(2f);
            player.transform.position = end.transform.position;
        }

        if (collision.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ui.SetActive(false);
    }
}
