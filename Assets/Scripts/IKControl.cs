using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour
{
    public static IKControl instance;
    [Range(1,100)]
    public int value;
    public Transform LeftHandCanvasUI;
    public Transform TargetRightHand;
    public Transform TargetLeftFoot;
    public Transform TargetRightFoot;

    [SerializeField] PlayerMovement playerParent;

    [Header("Ragdoll Systems")]
    [SerializeField] Collider[] ragdollColl;
    [SerializeField] Rigidbody[] ragdollrb;

    private Rigidbody rb;
    private Animator animator;
    //[SerializeField] float speed;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, 2.2f, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
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

    private void Physics(bool value)
    {
        foreach (Rigidbody childrensPhysics in ragdollrb)
        {
            childrensPhysics.isKinematic = !value;
            childrensPhysics.useGravity = value;
        }
    }
    private void Collider(bool value)
    {
        foreach (Collider childrensPhysics in ragdollColl)
        {
            childrensPhysics.isTrigger = value;
        }
    }
    public void RagdollEnabled(bool value)
    {
        Physics(value);
        Collider(!value);
        animator.enabled = !value;
        playerParent.speed = 0;
    }
}
