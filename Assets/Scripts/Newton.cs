using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newton : MonoBehaviour
{
    public GameObject Player;
    // public GameObject TheNPC;
    // public float TargetDistance;
    // public float AllowedDistance = 5;
    public float FollowSpeed;

    // public RaycastHit Shot;
   
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // void Update()
    // {
    //     transform.LookAt(Player.transform);

    //     if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)){
    //         TargetDistance = Shot.distance;

    //         if (TargetDistance >= AllowedDistance){
    //             FollowSpeed = 0.02f;
    //             animator.Play("xbot@Walking");
    //             transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
    //         }
    //         else {
    //             FollowSpeed = 0;
    //             animator.Play("xbot@Laughing");
    //         }
    //     }
    // }
    
    private void OnTriggerEnter(Collider other){
        transform.LookAt(Player.transform);
        if (other.tag == "Player"){
            Debug.Log("here");
            animator.SetBool("isWalking", true);
            Debug.Log("and here");
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
            Debug.Log("a here");
        }
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("BE");
        if (other.tag == "Player"){
            animator.SetBool("isWalking", false);
        }
    }

} 
