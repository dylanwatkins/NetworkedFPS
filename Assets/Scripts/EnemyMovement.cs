using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {


    public bool die;
    public GameObject player;
    public float speed = 0.01f;
    public Transform target;
    // public Transform player;
    public NavMeshAgent agent;



    void Start()
    {
        
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("Hunt", 2f);
    }


    void Hunt()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }
   

    void Update()
    {
        GetComponent<NavMeshAgent>().destination = target.transform.position;

       // Vector3 direction = (player.transform.position - transform.position).normalized;
        //float distance = (player.transform.position - transform.position).magnitude;
        //Vector3 move = transform.position + (direction * speed);
        //Debug.Log("Moving Toward Player");
        //transform.position = move;
        //transform.LookAt(target);
        //Debug.Log("Looking Toward Player");

    }
}
