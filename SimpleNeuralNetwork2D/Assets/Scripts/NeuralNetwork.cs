using System;
using System.Collections.Generic;

public class NeuralNetwork : IComparable<NeuralNetwork>
{
    private int[] _layers;
    private float[][] _neurons;
    private float[][][] _weights;

    public float Fitness { get; set; }

    public NeuralNetwork()
    {

    }

    public NeuralNetwork(int[] layers)
    {
        _layers = layers;

        SetNeurons();
        SetWeights();
    }


    public NeuralNetwork Copy()
    {
        return new NeuralNetwork()
        {
            _layers = this._layers,
            _neurons = this._neurons,
            _weights = this._weights,
        };
    }

    public NeuralNetwork(NeuralNetwork copyNetwork)
    {
        this._layers = new int[copyNetwork._layers.Length];
        for (int i = 0; i < copyNetwork._layers.Length; i++)
        {
            this._layers[i] = copyNetwork._layers[i];
        }

        SetNeurons();
        SetWeights();
        CopyWeights(copyNetwork._weights);
    }


    private void CopyWeights(float[][][] copyWeights)
    {
        for (int i = 1; i < _weights.Length; i++)
        {
            for (int j = 0; j < _weights[i].Length; j++)
            {
                for (int k = 0; k < _weights[i][j].Length; k++)
                {
                    _weights[i][j][k] = copyWeights[i][j][k];
                }
            }
        }
    }

    private void SetNeurons()
    {
        _neurons = new float[_layers.Length][];

        for (int i = 0; i < _layers.Length; i++)
        {
            _neurons[i] = new float[_layers[i]];
        }
    }


    private void SetWeights()
    {
        _weights = new float[_layers.Length][][];

        for (int l = 1; l < _layers.Length; l++)
        {
            _weights[l] = new float[_neurons[l].Length][];

            int neuronsInPrevLayer = _layers[l - 1];

            for (int n = 0; n < _neurons[l].Length; n++)
            {
                _weights[l][n] = new float[neuronsInPrevLayer];

                for (int w = 0; w < neuronsInPrevLayer; w++)
                {
                    _weights[l][n][w] = UnityEngine.Random.Range(-.5f, .5f);
                }
            }
        }
    }

    public float[] FeedForward(float[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            _neurons[0][i] = inputs[i];
        }

        for (int l = 1; l < _layers.Length; l++)
        {
            for (int n = 0; n < _neurons[l].Length; n++)
            {
                float value = 0f;

                for (int p = 0; p < _neurons[l - 1].Length; p++)
                {
                    value += _weights[l][n][p] * _neurons[l - 1][p];
                }

                _neurons[l][n] = (float)Math.Tanh(value);
            }
        }

        return _neurons[_neurons.Length - 1];
    }


    public void Mutate()
    {
        for (int l = 1; l < _weights.Length; l++)
        {
            for (int n = 0; n < _weights[l].Length; n++)
            {
                for (int w = 0; w < _weights[l][n].Length; w++)
                {
                    _weights[l][n][w] = GetMutatetWeight(_weights[l][n][w]);
                }
            }
        }
    }

    private float GetMutatetWeight(float weight)
    {
        float rand = UnityEngine.Random.Range(0f, 100f);

        if (rand <= 2f)
        {
            weight *= -1f;
        }
        else if (rand <= 4f)
        {
            weight = UnityEngine.Random.Range(-0.5f, 0.5f);
        }
        else if (rand <= 6f)
        {
            float factor = UnityEngine.Random.Range(0f, 1f) + 1f;
            weight *= factor;
        }
        else if (rand <= 8f)
        {
            float factor = UnityEngine.Random.Range(0f, 1f);
            weight *= factor;
        }

        return weight;
    }


    public int CompareTo(NeuralNetwork other)
    {
        if (other == null) return 1;

        if (Fitness > other.Fitness) return 1;
        if (Fitness < other.Fitness) return -1;
        return 0;
    }
}
