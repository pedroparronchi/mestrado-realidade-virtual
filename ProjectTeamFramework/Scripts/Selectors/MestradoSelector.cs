using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

//Usada para tocar um som a partir do clique em um objeto
public class MestradoSelector : BaseSelector
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject targetParent;

    [SerializeField] Animator animator;
    [SerializeField] AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        if (!animator)
            animator = target.GetComponent<Animator>();

        if (!audioSource)
            audioSource = target.GetComponent<AudioSource>();
    }

    public override void OnInteractionTrigger(InteractionModes mode)
    {

        foreach (Transform child in targetParent.transform)
        {
            if(target.gameObject.name != child.gameObject.name)
                child.gameObject.SetActive(false);
        }

        if (target)
        {
            target.SetActive(!target.activeSelf);
        }

        animator.enabled = true;
        audioSource.Play();
        OnFinish();
    }

    protected override void OnFinish()
    {
        base.Finished(this.gameObject);
    }
}
