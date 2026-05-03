using System.Threading;
using UnityEngine;

public class damagePLayer : MonoBehaviour
{
    public MonoBehaviour moveDragon;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Atacking"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
            }
        }
    }
}
