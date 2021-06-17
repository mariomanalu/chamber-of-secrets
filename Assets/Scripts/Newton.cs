using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newton : MonoBehaviour
{
    public GameObject Player;
    public GameObject TheNPC;
    public float TargetDistance;
    private float AllowedDistance = 1;
    public float FollowSpeed;

    public RaycastHit Shot;

    public Animator animator;
    void Update()
    {
        transform.LookAt(Player.transform);

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)){
            TargetDistance = Shot.distance;

            if (TargetDistance >= AllowedDistance){
                FollowSpeed = 0.02f;
                animator.SetBool("isWalking", true);
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
            }
            else {
                FollowSpeed = 0;
                animator.SetBool("isWalking", false);
            }
        }
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
