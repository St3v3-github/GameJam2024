using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TaskListManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    private string filePath;
    string[] allLines;

    private int currentLine = 1;

    private GameObject prankManagerObject;
    private PrankManager prankManagerScript;


    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/TextFiles/TaskList.txt";
        allLines = System.IO.File.ReadAllLines(filePath);

        textMeshPro.SetText(allLines[currentLine - 1]);

        prankManagerObject = GameObject.Find("PrankManager");
        prankManagerScript = prankManagerObject.GetComponent<PrankManager>();

        GameObject player = GameObject.Find("PlayerCharacter");
        Inventory invent = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(prankManagerScript.index == 0)
        {
           
        }
    }

    void UpdateTaskList(int newCurrentLine)
    {
        currentLine = newCurrentLine;

        textMeshPro.SetText(allLines[currentLine - 1]);
    }

}
