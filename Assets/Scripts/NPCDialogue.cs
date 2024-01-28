using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;

public class NPCDialogue : MonoBehaviour, IInteractable
{
    private GameObject dialogueManagerObject;
    private DialogueManager dialogueManagerScript;

    private GameObject prankManagerObject;
    private PrankManager prankManagerScript;

    private enum Prank {Whoopie, Fire, Banana};
    private Prank currentPrank = Prank.Whoopie;

    void Start()
    {
        dialogueManagerObject = GameObject.Find("DialogueManager");
        dialogueManagerScript = dialogueManagerObject.GetComponent<DialogueManager>();

        prankManagerObject = GameObject.Find("PrankManager");
        prankManagerScript = prankManagerObject.GetComponent<PrankManager>();
    }

    public void Interact()
    {

        //Set Current Prank
        if (prankManagerScript.index == 0)
        {
            currentPrank = Prank.Whoopie;
        }

        if (prankManagerScript.index == 1)
        {
            currentPrank = Prank.Fire;
        }

        //Set Dialogue
        if (prankManagerScript.hintIndex == 0)
        {
            dialogueManagerScript.ShowText(1);
            return;
        }
         
        switch (currentPrank)
        {
            case Prank.Whoopie:

                if (prankManagerScript.hintIndex == 1)
                {
                    dialogueManagerScript.ShowText(5);
                }

                if (prankManagerScript.hintIndex == 2)
                {
                    dialogueManagerScript.ShowText(6);

                }

                if (prankManagerScript.hintIndex == 3)
                {
                    dialogueManagerScript.ShowText(7);
                }

                break;

            case Prank.Fire:
                {
                    if (prankManagerScript.hintIndex == 1)
                    {
                        dialogueManagerScript.ShowText(35);
                    }

                    if (prankManagerScript.hintIndex == 2)
                    {
                        dialogueManagerScript.ShowText(36);

                    }

                    if (prankManagerScript.hintIndex == 3)
                    {
                        dialogueManagerScript.ShowText(37);
                    }

                    break;
                }

            case Prank.Banana:
                {
                    if (prankManagerScript.hintIndex == 1)
                    {
                        dialogueManagerScript.ShowText(45);
                    }

                    if (prankManagerScript.hintIndex == 2)
                    {
                        dialogueManagerScript.ShowText(46);

                    }

                    if (prankManagerScript.hintIndex == 3)
                    {
                        dialogueManagerScript.ShowText(47);
                    }

                    break;
                }
        }
    }
}
