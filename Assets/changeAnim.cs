using UnityEngine;
using UnityEngine.SceneManagement;

public class changeAnim : MonoBehaviour
{
    private Animator anim;
    public DialogueSystem ds;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walking", true);
    }

    public void ChangeAnim()
    {
        if(anim.GetBool("walking") == false)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeTrigger(string s)
    {
        anim.SetTrigger(s);
    }

    public void Inicio()
    {
        ds.StartDialogue();
    }



    public void ChangeBool(string s)
    {
        if (anim.GetBool(s) == false)
        {
            anim.SetBool(s, true);
        }
        else
        {
            anim.SetBool(s, false);
        }
    }

    public void ChangeFast()
    {
        anim.SetTrigger("fast");
    }

    public void ChangeSlow()
    {
        anim.SetTrigger("slow");
    }
}
