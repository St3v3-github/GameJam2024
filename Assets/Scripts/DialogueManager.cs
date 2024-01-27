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

    private int currentLine;

    [SerializeField] private Canvas DialogueCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //ShowText(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowText(int lineNumber)
    {
        DialogueCanvas.gameObject.SetActive(true);

        currentLine = lineNumber;

        filePath = Application.dataPath + "/TextFiles/Dialogue.txt";

        string[] allLines = System.IO.File.ReadAllLines(filePath);
        textMeshPro.SetText(allLines[currentLine - 1]);
    }

    void HideText()
    {
        DialogueCanvas.gameObject.SetActive(false);
    }
}
