using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPad : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Animator _animator;

    public Scrollbar ScrollBar => _scrollbar;

    public void Open()
    {
        Debug.Log(_animator);
        _animator.SetBool("Open",true);
    }
    public void Close()
    {
        _animator.SetBool("Closed",true);
        _animator.SetBool("Open",false);
    }
}
