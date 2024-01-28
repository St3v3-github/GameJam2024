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

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/TextFiles/TaskList.txt";
        allLines = System.IO.File.ReadAllLines(filePath);

        textMeshPro.SetText(allLines[currentLine - 1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTaskList()
    {
        currentLine++;

        textMeshPro.SetText(allLines[currentLine - 1]);
    }
}
