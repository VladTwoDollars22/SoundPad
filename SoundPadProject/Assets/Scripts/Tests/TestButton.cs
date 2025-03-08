using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void OnClicked()
    {
        _animator.SetBool("Open",true);
    }

    public void OnStop()
    {
        _animator.SetBool("Closed",true);
        _animator.SetBool("Open",false);
    }
}
