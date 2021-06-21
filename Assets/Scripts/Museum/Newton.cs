using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newton : MonoBehaviour
{
    public GameObject Player;
    public GameObject TheNPC;
    public float TargetDistance;
    //private float AllowedDistance = 1;
    //private float FollowSpeed = 0.02f;

    // public RaycastHit Shot;
    UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;

    void Start(){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    // void Update(){
    //     transform.LookAt(Player.transform);
    //     animator.SetBool("isWalking", true);
    //     agent.SetDestination(transform.position);
    // }

   // Using the video with Japanese Anime Character
    void Update()
    {
        transform.LookAt(Player.transform);
        animator.SetBool("isWalking", true);
        agent.SetDestination(transform.position);
    }
    
    //  void Update()
    // {
    //     transform.LookAt(Player.transform);

    //     if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)){
    //         TargetDistance = Shot.distance;

    //         if (TargetDistance >= AllowedDistance){
    //             FollowSpeed = 0.02f;
    //             TheNPC.GetComponent<Animation>().Play("Walking");
    //             transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
    //         }
    //         else {
    //             FollowSpeed = 0;
    //             TheNPC.GetComponent<Animation>().Play("Acknowledging");
    //         }
    //     }
    // }
    

    // private void OnTriggerEnter(Collider other){
    //     transform.LookAt(Player.transform);
    //     if (other.tag == "Player"){
    //         FollowSpeed = 0.02f;
    //         animator.SetBool("isWalking", true);
    //         Vector3 newPosition = new Vector3(Player.transform.position.x + 1, 0, Player.transform.position.z);
    //         transform.position = Vector3.MoveTowards(transform.position, newPosition, FollowSpeed);
    //     }
    // }

    // private void OnTriggerExit(Collider other){
    //     Debug.Log("BE");
    //     if (other.tag == "Player"){
    //         FollowSpeed = 0;
    //         animator.SetBool("isWalking", false);
    //     }
    // }

} 
