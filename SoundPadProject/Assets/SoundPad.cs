using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundPad : MonoBehaviour
{
    [SerializeField] private Scrollbar _scrollbar;
    private Animator _animator;

    public Scrollbar ScrollBar => _scrollbar;

    public void Open()
    {
        _animator.SetBool("Open",true);
    }
    public void Close()
    {
        _animator.SetBool("Closed",true);
        _animator.SetBool("Open",false);
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
