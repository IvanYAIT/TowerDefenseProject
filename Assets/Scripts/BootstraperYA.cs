using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstraperYA : MonoBehaviour
{
    [SerializeField] private Menu menu;

    StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine(menu);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
