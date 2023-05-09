using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject loquet;
    public Transform attachmentPoint;

    void Start()
    {
        FixedJoint2D joint = loquet.AddComponent<FixedJoint2D>();
        joint.connectedBody = GetComponent<Rigidbody2D>();
        joint.anchor = attachmentPoint.localPosition;
    }
}
