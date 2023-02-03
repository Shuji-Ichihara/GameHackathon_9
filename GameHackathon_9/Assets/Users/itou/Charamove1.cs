using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charamove1 : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Run());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Run()
    {
        anim.SetBool("isRun", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isRun", false);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Run());
    }
}
