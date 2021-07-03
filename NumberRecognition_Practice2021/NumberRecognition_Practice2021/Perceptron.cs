using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NumberRecognition_Practice2021
{
    [Serializable]
    class Perceptron
    {
        List<Layer> layers;
        public Perceptron(int[] neuronsPerlayer)
        {
            layers = new List<Layer>();
            Random r = new Random();

            for (int i = 0; i < neuronsPerlayer.Length; i++)
            {
                layers.Add(new Layer(neuronsPerlayer[i], i == 0 ? neuronsPerlayer[i] : neuronsPerlayer[i - 1], r));
            }
        }

        public double[] Activate(double[] inputs)
        {
            double[] outputs = new double[0];
            for (int i = 1; i < layers.Count; i++)
            {
                outputs = layers[i].Activate(inputs);
                inputs = outputs;
            }
            return outputs;
        }

        double IndividualError(double[] realOutput, double[] desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < realOutput.Length; i++)
            {
                err += Math.Pow(realOutput[i] - desiredOutput[i], 2);
            }
            return err;
        }
        double GeneralError(List<double[]> input, List<double[]> desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < input.Count; i++)
            {
                err += IndividualError(Activate(input[i]), desiredOutput[i]);
            }
            return err;
        }

        List<double[]> sigmas;
        List<double[,]> deltas;
        void SetSigmas(double[] desiredOutput)
        {
            sigmas = new List<double[]>();
            for (int i = 0; i < layers.Count; i++)
            {
                sigmas.Add(new double[layers[i].numberOfNeurons]);
            }
            for (int i = layers.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    if (i == layers.Count - 1)
                    {
                        double y = layers[i].neurons[j].lastActivation;
                        sigmas[i][j] = (Neuron.Sigmoid(y) - desiredOutput[j]) * Neuron.SigmoidDerivated(y);
                    }
                    else
                    {
                        double sum = 0;
                        for (int k = 0; k < layers[i + 1].numberOfNeurons; k++)
                        {
                            sum += layers[i + 1].neurons[k].weights[j] * sigmas[i + 1][k];
                        }
                        sigmas[i][j] = Neuron.SigmoidDerivated(layers[i].neurons[j].lastActivation) * sum;
                    }
                }
            }
        }

        void SetDeltas()
        {
            deltas = new List<double[,]>();
            for (int i = 0; i < layers.Count; i++)
            {
                deltas.Add(new double[layers[i].numberOfNeurons, layers[i].neurons[0].weights.Length]);
            }
        }

        void AddDelta()
        {
            for (int i = 1; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    for (int k = 0; k < layers[i].neurons[j].weights.Length; k++)
                    {
                        deltas[i][j, k] += sigmas[i][j] * Neuron.Sigmoid(layers[i - 1].neurons[k].lastActivation);
                    }
                }
            }
        }
        void UpdateBias(double alpha)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    layers[i].neurons[j].bias -= alpha * sigmas[i][j];
                }
            }
        }
        void UpdateWeights(double alpha)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                for (int j = 0; j < layers[i].numberOfNeurons; j++)
                {
                    for (int k = 0; k < layers[i].neurons[j].weights.Length; k++)
                    {
                        layers[i].neurons[j].weights[k] -= alpha * deltas[i][j, k];
                    }
                }
            }
        }
        void ApplyBackPropagation(List<double[]> input, List<double[]> desiredOutput, double alpha)
        {
            SetDeltas();
            for (int i = 0; i < input.Count; i++)
            {
                Activate(input[i]);
                SetSigmas(desiredOutput[i]);
                UpdateBias(alpha);
                AddDelta();
            }
            UpdateWeights(alpha);

        }

        List<string> log;
        public bool Learn(List<double[]> input, List<double[]> desiredOutput, double alpha, double maxError, int maxIterations, int iter_save = 1)
        {
            //  Random rnd = new Random();
            //  alpha = rnd.NextDouble() + 0.1;
            alpha = 0.5;
            double err = 99999;
            log = new List<string>();
            int it = maxIterations;
            while (err > maxError)
            {

                ApplyBackPropagation(input, desiredOutput, alpha);
                err = GeneralError(input, desiredOutput);


                // if ((it - maxIterations) % 1000 == 0)
                // {
                Console.WriteLine(err + " iterations: " + (it - maxIterations));
                // }


                //if (net_path != null)
                //{
                //    if ((it - maxIterations) % iter_save == 0)
                //    {
                //        save_net(net_path);
                //        Console.WriteLine("Save net to " + net_path);
                //    }
                //}

                log.Add(err.ToString());
                maxIterations--;

                //if (Console.KeyAvailable)
                //{
                //    System.IO.File.WriteAllLines(@"LogTail.txt", log.ToArray());
                //    return true;
                //}
                if (err > 15)
                {
                    return false;
                }
                if (maxIterations <= 0)
                {
                //    Console.WriteLine("MINIMO LOCAL");
                //    System.IO.File.WriteAllLines(@"LogTail.txt", log.ToArray());
                    return false;
                }

            }
            Console.WriteLine("complete");
            System.IO.File.WriteAllLines(@"LogTail.txt", log.ToArray());
            return true;
        }



        public void save_net(String neuralNetworkPath)
        {
            FileStream fs = new FileStream(neuralNetworkPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, this);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public static Perceptron GetPerceptronFromByte (byte[] data)
        {
            Perceptron p;
            using (MemoryStream ms = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                ms.Seek(0, SeekOrigin.Begin);
                p = (Perceptron)formatter.Deserialize(ms);
            }
            return p;
        }

        public static byte[] GetByteFromPerceptron(Perceptron p)
        {
            byte[] data;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, p);
                data = ms.ToArray();
            }
            return data;
        }
        public static Perceptron Load(String neuralNetworkPath)
        {
            //FileStream fs = new FileStream(neuralNetworkPath, FileMode.Open);
            Perceptron p = null;
            //try
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();

            //    // Deserialize the hashtable from the file and 
            //    // assign the reference to the local variable.
            //    p = (Perceptron)formatter.Deserialize(fs);
            //}
            //catch (SerializationException e)
            //{
            //    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
            //    throw;
            //}
            //finally
            //{
            //    fs.Close();
            //}

            return p;
        }
    }
}
