using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newton : MonoBehaviour
{
    private GameObject player;
    [SerializeField] 
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other){

       Debug.Log("B");
        if (other.tag == "Player"){
            animator.SetBool("isThinking", true);
        }
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("BE");
        if (other.tag == "Player"){
            animator.SetBool("isThinking", false);
        }
    }

} 
