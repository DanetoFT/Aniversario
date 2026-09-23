using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string[] lines;
    public float textSpeed;
    public GameObject panel;
    public GameObject endPanel;
    Animator animator;
    bool isStarted;

    public bool activate;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        activate = false;
        animator = GetComponent<Animator>();
        text.text = string.Empty;
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (text.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    public void Skip()
    {
        if (text.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            text.text = lines[index];
        }
    }

    public void StartDialogue()
    {
        index = 0;
        isStarted = true;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            panel.gameObject.SetActive(false);
            endPanel.gameObject.SetActive(true);
        }
    }

    public void Destroyer()
    {
        activate = true;
        gameObject.SetActive(false);
    }
}
