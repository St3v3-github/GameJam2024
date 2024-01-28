using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirePrank : Prank
{
    public Transform fireLocation;
    public GameObject Fire;
    public Animator animator;




    public override void startPrank()
    {
        GameObject obj = Instantiate(Fire, fireLocation.position, Quaternion.identity);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.IgnitionSound, this.transform.position);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.Player_LaughSound, this.transform.position);
        animator.SetBool("IsAngry", true);
    }

}
