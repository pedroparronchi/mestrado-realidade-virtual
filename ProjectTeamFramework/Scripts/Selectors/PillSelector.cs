using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

//Usada para tocar um som a partir do clique em um objeto
public class PillSelector : BaseSelector
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject heartTarget;
    [SerializeField]
    private GameObject targetParent;

    [SerializeField] Animator animator;

    [SerializeField] Animator animatorHeart;
    [SerializeField] AudioSource audioSourceHeart;


    // Start is called before the first frame update
    void Start()
    {
        if (!animator)
            animator = target.GetComponent<Animator>();


        if (!audioSourceHeart)
            audioSourceHeart = target.GetComponent<AudioSource>();
    }

    public override void OnInteractionTrigger(InteractionModes mode)
    {

        foreach (Transform child in targetParent.transform)
        {
            if (child.gameObject.name != heartTarget.gameObject.name)
                child.gameObject.SetActive(false);

        }

        if (target)
            target.SetActive(!target.activeSelf);

        if (heartTarget)
            heartTarget.SetActive(!heartTarget.activeSelf);

        animator.enabled = true;
        animatorHeart.enabled = true;
        audioSourceHeart.Play();
        OnFinish();
    }

    protected override void OnFinish()
    {
        base.Finished(this.gameObject);
    }
}
