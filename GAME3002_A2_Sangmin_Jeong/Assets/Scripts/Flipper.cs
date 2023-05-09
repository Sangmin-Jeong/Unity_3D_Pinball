using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    //Power of spring
    [SerializeField]
    private float m_fSpringConst = 0f;
    //Position when it rests
    [SerializeField]
    private float m_fOriginalPos = 0f;
    //Target Position 
    [SerializeField]
    private float m_fPressedPos = 0f;
    //For Friction
    [SerializeField]
    private float m_fFlipperSpringDamp = 0f;
    //Setting Input key
    [SerializeField]
    private KeyCode m_flipperInput;

    private HingeJoint m_hingeJoint = null;
    private JointSpring m_jointSpring;

    private void Start()
    {
        m_hingeJoint = GetComponent<HingeJoint>();
        m_hingeJoint.useSpring = true;

        //JointSpring is used add a spring force to HingeJoint
        m_jointSpring = new JointSpring();
        m_jointSpring.spring = m_fSpringConst;
        m_jointSpring.damper = m_fFlipperSpringDamp;
        //pass values of our jointspring to the hingejoint's spring
        m_hingeJoint.spring = m_jointSpring;
    }

    private void OnFlipperPressedInternal()
    {
        //Change Spring's Target position to PressedPos to pull up the Flipper
        m_jointSpring.targetPosition = m_fPressedPos;
        m_hingeJoint.spring = m_jointSpring;
    }

    private void OnFlipperReleasedInternal()
    {
        //Change Spring's Target position to OriginalPos to get back the rest position
        m_jointSpring.targetPosition = m_fOriginalPos;
        m_hingeJoint.spring = m_jointSpring;
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_flipperInput))
        {
            OnFlipperPressedInternal();
        }

        if (Input.GetKeyUp(m_flipperInput))
        {
            OnFlipperReleasedInternal();
        }
    }
}
