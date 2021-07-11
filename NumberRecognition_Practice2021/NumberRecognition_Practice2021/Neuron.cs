using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognition_Practice2021
{
    [Serializable]
    class Neuron
    {
        public double[] weights; //веса 
        public double lastActivation; //последняя активация
        public double bias; //сдвиг
        public static double Sigmoid(double input)//сигмоида
        {
             return 1 / (1 + Math.Exp(-input));
        }
        public static double SigmoidDerivated(double input)//производная от сигмоиды
        {
            double y = Sigmoid(input);
            return y * (1 - y);
        }
        public Neuron(int numberOfInputs, Random r) //конструктор (кол-во входов, рандом)
        {
            bias = 5 * r.NextDouble() - 2.5;            
            weights = new double[numberOfInputs];
            for (int i = 0; i < numberOfInputs; i++)
            {
                weights[i] = 5*r.NextDouble()-2.5;
            }
        }
        public double Activate(double[] inputs) //активация массив входов
        {
            double activation = bias;

            for (int i = 0; i < weights.Length; i++)
            {
                activation += weights[i] * inputs[i];
            }

            lastActivation = activation;
            return Sigmoid(activation);
        }
    }
}
