using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorMagic;
    [SerializeField]
    private Animator animatorCube;

    void Start()
    {
        animatorMagic = GetComponent<Animator>();
        animatorMagic.SetBool("Magic", false);
        animatorCube = GetComponent<Animator>();
        animatorCube.SetBool("Throw", false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Cube());
    }

    IEnumerator Cube()
    {
        if (Input.GetKey("e"))
        {
            animatorMagic.SetBool("Magic", true);
            animatorCube.SetBool("Throw", true);
            yield return new WaitForSeconds(0.2f);
            animatorMagic.SetBool("Magic", false);
            animatorCube.SetBool("Throw", false);
        }
        
    }
}
