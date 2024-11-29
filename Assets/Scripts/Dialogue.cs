using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDialogue;
    public string[] lines;
    public float textSpeed;
    private int index;
    private void Start()
    {
        textDialogue.text = string.Empty;
        StartDialogue();
    }
    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textDialogue.text == lines[index])
            {
                NextLines();
            }
            else
            {
                StopAllCoroutines();
                textDialogue.text = lines[index];
            }
        }
    }
    private void NextLines()
    {
        if (index < lines.Length-1)
        {
            index++;
            textDialogue.text=string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
