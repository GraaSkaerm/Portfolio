using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain
{
    private Vector2[] _inputs;

    public Vector2[] Inputs { get => _inputs; set => _inputs = value; }
    


    public Brain(int inputSize)
    {
        _inputs = GenerateRandomeInputs(inputSize);
    }

    private Vector2[] GenerateRandomeInputs(int length)
    {

        Vector2[] inputs = new Vector2[length];

        for (int i = 0; i < length; i++)
        {
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            inputs[i] = new Vector2(x, y);
        }

        return inputs;
        
    }

    


    
    

}
