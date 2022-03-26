using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Agent : MonoBehaviour
{
    [SerializeField] private bool _canMove;

    public Brain Brain { get; set; }
    

    private void Start()
    {
        Brain = new Brain(100);
    }




    private void Move()
    {
        if (_canMove == false) return;


    }




}


