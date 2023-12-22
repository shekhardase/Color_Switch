using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Player ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.y > transform.position.y) //IF player Passed the postion do next
        {
            transform.position = new Vector3(transform.position.x , Player.position.y , transform.position.z);  //Follow player
        }

        
    }
}
