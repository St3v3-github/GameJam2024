using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WhoopeePrank : Prank
{
    public Transform whoopeeLocation;
    public GameObject whoopee;
    public GameObject employee;
    public GameObject obj;
    public GameObject confetti;
    public bool placed = false;

    public override void Update()
    {
        float distance = Vector3.Distance(employee.transform.position, transform.position);
        if (distance <= 1.1f && placed)
        {
            StartCoroutine(Detonation());
        }
    }

    public override void startPrank()
    {
        obj = Instantiate(whoopee, whoopeeLocation);
        confetti = obj.transform.GetChild(0).gameObject;
        placed = true;
    }

    private IEnumerator Detonation()
    {
        placed = false;
        Debug.Log("WHOOPeeED");
        yield return new WaitForSeconds(2f);
        confetti.GetComponent<ParticleSystem>().Play();
        AudioManager.instance.PlayOneShot(FMODEvents.instance.FartSound, this.transform.position);
        
    }
}
