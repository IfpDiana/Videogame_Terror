using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    Animator anim;
    public int isSprintingHash;
    public int isWalkingHash;
    public int isCrouchingHash;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isSprintingHash = Animator.StringToHash("IsSprinting");
        isCrouchingHash = Animator.StringToHash("isCrouching");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsWalking = anim.GetBool(isWalkingHash);
        bool IsSrpinting = anim.GetBool(isSprintingHash);
        bool IsCrouching = anim.GetBool(isCrouchingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool crouchPressed = Input.GetKey(KeyCode.LeftControl);
        if (!IsWalking && forwardPressed)
        {
            anim.SetBool("IsWalking", true);
        }
        if (IsWalking && !forwardPressed)
        {
            anim.SetBool("IsWalking", false);
        }
        if (!IsSrpinting && (forwardPressed && runPressed))
        {
            anim.SetBool("IsSprinting", true);
        }
        if (IsSrpinting && !forwardPressed && !runPressed)
        {
            anim.SetBool("IsSprinting", false);
        }
        if (!IsCrouching && (forwardPressed && crouchPressed))
        {
            anim.SetBool("isCrouching", true);
        }
        if (IsCrouching && !forwardPressed && !crouchPressed)
        {
            anim.SetBool("isCrouching", false);
        }
    }
}
