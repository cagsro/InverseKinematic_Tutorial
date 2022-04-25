using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour
{
    Animator animator;
    public Transform LeftHandCanvasUI;
    public Transform TargetRightHand;
    public Transform TargetLeftFoot;
    public Transform TargetRightFoot;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, 2.2f, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnAnimatorIK(int layerIndex)
    {
        //Left Hand IK Control
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandCanvasUI.position);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandCanvasUI.rotation);
        //Right Hand IK Control
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKPosition(AvatarIKGoal.RightHand, TargetRightHand.position);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKRotation(AvatarIKGoal.RightHand, TargetRightHand.rotation);
        //Left Foot IK Control
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
        animator.SetIKPosition(AvatarIKGoal.LeftFoot, TargetLeftFoot.position);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        animator.SetIKRotation(AvatarIKGoal.LeftFoot, TargetLeftFoot.rotation);
        //Right Foot IK Control
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
        animator.SetIKPosition(AvatarIKGoal.RightFoot, TargetRightFoot.position);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
        animator.SetIKRotation(AvatarIKGoal.RightFoot, TargetRightFoot.rotation);

    }
}
