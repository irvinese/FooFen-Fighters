using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines; // Increase the size of this array as needed
    public float textSpeed;
    private bool isTyping;
    private bool waitForInput;
    private int charIndex; // Track the index of the character being typed
    private int currentLineIndex = 0; // Track the current line being displayed
    private bool dialogueActive; // Tracks if dialogue is active

    void Start()
    {
        textComponent.text = string.Empty;
        isTyping = false;
        waitForInput = false;
        currentLineIndex = 0; // Initialize the current line index
        dialogueActive = false;
    }

    void Update()
    {
        if (dialogueActive)
        {
            if (waitForInput && Input.GetKeyDown(KeyCode.R))
            {
                ContinueDialogue();
            }
        }
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        gameObject.SetActive(true);
        StartCoroutine(DisplayDialogue());
        dialogueActive = true;
    }

    public void ContinueDialogue()
    {
        if (currentLineIndex < lines.Length - 1)
        {
            currentLineIndex++;
            StartCoroutine(TypeLine(lines[currentLineIndex]));
        }
        else
        {
            // All lines have been displayed, dialogue remains active
            waitForInput = false;
        }
    }

    public void StopDialogue()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);
        dialogueActive = false;
    }

    private IEnumerator DisplayDialogue()
    {
        // Wait for the first line to be displayed
        yield return StartCoroutine(TypeLine(lines[currentLineIndex]));
        waitForInput = true;
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;
        charIndex = 0; // Initialize the character index
        textComponent.text = string.Empty;

        while (charIndex < line.Length)
        {
            if (charIndex == 0)
            {
                // Display the first character instantly
                textComponent.text += line[charIndex];
            }
            else
            {
                // Display subsequent characters with delay
                yield return new WaitForSeconds(textSpeed);
                textComponent.text += line[charIndex];
            }
            charIndex++;
        }
        isTyping = false;
    }
}
