using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject maincam, timer, cutscene, player;
    public Animator anim;
    public string animationName;
    PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName(animationName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            maincam.SetActive(true);
            timer.SetActive(true);
            cutscene.SetActive(false);
            pc = player.GetComponent<PlayerController>();
            pc.enabled = true;
        }
    }
}
