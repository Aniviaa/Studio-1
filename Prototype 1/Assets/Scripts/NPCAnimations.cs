using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimations : MonoBehaviour
{

    public Animator npcAnim;

    public int animDelay;
    public int cheerClap;
    public int twirl;

    public bool sit;
    public bool talk;
    public bool pushUp;
    public bool punch;
    public bool dance;
    public bool idle;
    public bool cheer;
    public bool clap;
    public bool dancecheer;

    // Start is called before the first frame update
    void Start()
    {
        npcAnim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animDelay = Random.Range(0, 10);

        cheerClap = Random.Range(0, 10);

        twirl = Random.Range(0, 10);

        npcAnim.SetBool("Dance", dance);
        npcAnim.SetBool("Idle", idle);
        npcAnim.SetBool("Sit", sit);
        npcAnim.SetBool("Talk", talk);
        npcAnim.SetBool("PushUp", pushUp);
        npcAnim.SetBool("Punch", punch);
        npcAnim.SetBool("Clap", clap);
        npcAnim.SetBool("Cheer", cheer);

        npcAnim.SetBool("DanceCheer", dancecheer);
        npcAnim.SetInteger("CheerClap", cheerClap);
        npcAnim.SetInteger("SitandStand", animDelay);
        npcAnim.SetInteger("Twirl", twirl);

    }
}
