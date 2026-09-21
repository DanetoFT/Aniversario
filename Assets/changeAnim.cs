using UnityEngine;

public class changeAnim : MonoBehaviour
{
    private Animator anim;

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

    public void ChangeFast()
    {
        anim.SetTrigger("fast");
    }

    public void ChangeSlow()
    {
        anim.SetTrigger("slow");
    }
}
