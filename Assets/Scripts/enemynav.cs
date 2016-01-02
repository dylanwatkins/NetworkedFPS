﻿using UnityEngine;
using System.Collections;

public class enemynav : MonoBehaviour
{

    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player)
        {
            Debug.Log("Make sure your player is tagged!!");
        }
    }

    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
    }
}

