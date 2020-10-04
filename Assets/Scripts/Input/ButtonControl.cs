using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonControl : MonoBehaviour
{
    /// <summary>
    /// Vertical input axis
    /// </summary>
    [SerializeField] string inputName = "Button Control";

    /// <summary>
    /// Runs when button is first pressed down
    /// </summary>
    public UnityEvent onButtonDown = new UnityEvent();

    /// <summary>
    /// Runs when button releases
    /// </summary>
    public UnityEvent onButtonUp = new UnityEvent();

    /// <summary>
    /// Runs once an update while button is down
    /// </summary>
    public UnityEvent whileButtonDown = new UnityEvent();

    /// <summary>
    /// Button state
    /// </summary>
    bool _value = false;

    /// <summary>
    /// Send value updates here to trigger events and store the input
    /// </summary>
    public bool Value { 
        get => _value; 
        set {
            if (value != _value)
            {
                _value = value;
                if (value)
                    onButtonDown.Invoke();
                else
                    onButtonUp.Invoke();
            }
            if (value)
                whileButtonDown.Invoke();

        } 
    }

    // Update is called once per frame
    void Update()
    {
        Value = Input.GetButton(inputName);
    }
}
