using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    private string filePath;
    string[] allLines;

    private int currentLine;

    [SerializeField] private Canvas DialogueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + "/TextFiles/Dialogue.txt";
        allLines = System.IO.File.ReadAllLines(filePath);

        //ShowText(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowText(int lineNumber)
    {
        DialogueCanvas.gameObject.SetActive(true);

        currentLine = lineNumber;
        textMeshPro.SetText(allLines[currentLine - 1]);
    }

    void HideText()
    {
        DialogueCanvas.gameObject.SetActive(false);
    }
}
