using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MagicController : MonoBehaviour
{
    [SerializeField]
    private Animator animatorSword;
    
    public List<Slash> slashes;

    void Start()
    {
        animatorSword = GetComponent<Animator>();
        animatorSword.SetBool("Sword", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            StartCoroutine(Cube());
            animatorSword.SetBool("Sword", true);
        }
        
    }

    IEnumerator Cube()
    {
        for (int i = 0; i < slashes.Count; i++)
        {
            yield return new WaitForSeconds(slashes[i].delay);
            slashes[i].slashobj.SetActive(true);
        }
        animatorSword.SetBool("Sword", false);
        yield return new WaitForSeconds(3f);
        DestroySlash();
    }

    void DestroySlash()
    {
        for (int i = 0; i < slashes.Count; i++)
        {
            slashes[i].slashobj.SetActive(false);
        }
    }

    [System.Serializable]
    public class Slash
    {
        public GameObject slashobj;
        public float delay;
    }
}
