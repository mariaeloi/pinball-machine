using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public string axisName;

    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float spring = 10000f;
    public float damper = 150f;

    private HingeJoint hinge;
    private JointSpring jointSpring;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        hinge.useLimits = true; //Habilita os limites da junta
        JointLimits jointLimits = new JointLimits();
        if(pressedPosition < 0)
        {
            jointLimits.min = pressedPosition;
        }
        else
        {
            jointLimits.max = pressedPosition;
        }
        hinge.limits = jointLimits;

        hinge.useSpring = true; //Ativa a mola da junta
        //Para a mola da junta
        jointSpring = new JointSpring();
        jointSpring.spring = spring; //spring tenta alcançar o ângulo alvo
        jointSpring.damper = damper; //damper amortece a velocidade angular
    }
    
    void Update()
    {
        //Definindo posição alvo da mola, por ângulo
        if(Input.GetAxis(axisName) == 1)
        {
            jointSpring.targetPosition = pressedPosition;
        }
        else
        {
            jointSpring.targetPosition = restPosition;
        }
        hinge.spring = jointSpring;
    }
}
