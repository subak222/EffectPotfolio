using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isDown", false);
        animator.SetBool("isUp", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            StartCoroutine(Water());
        }
    }

    IEnumerator Water()
    {
        animator.SetBool("isDown", true);
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("isDown", false);
        yield return new WaitForSeconds(4.0f);
        animator.SetBool("isUp", true);
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("isUp", false);
    }
}
