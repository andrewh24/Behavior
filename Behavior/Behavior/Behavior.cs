﻿using System;
using System.Collections;
using System.Collections.Generic;

public class Behavior
{
    public class AnimationData
    {
        private int ID { get; set; }
        private string name { get; set; }
        private int weight { get; set; }

        public AnimationData(int id, string name, int weight)
        {
            this.ID = id;
            this.name = name;
            this.weight = weight;
        }

        public int GetID { get { return ID; } }
        public string GetName { get { return name; } }
        public int GetWeight { get { return weight; } }

        public int SetWeight(int value)
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Weight can't be negative.");
            }
            else
            {
                weight = value;
            }

            return value;
        }
        public override string ToString()
        {
            string data = String.Format("{0}", name);
            return data;
        }
    }

    public string GetRandomDirection()
    {
        Random rand = new Random();
        int direction = rand.Next(2);

        if (direction == 0)
        {
            return "left";
        }
        else
        {
            return "right";
        }
    }

    public string GetRandomWithWeight(List<AnimationData> list)
    {
        Random rnd = new Random();
        int weightTotal = 0;
        int total = 0;
        int i = 0;
        int[] cumulativeWeights = new int[list.Count];
        int cumulative = 0;

        // calculating cumulative weights to separate array
        for (i = 0; i < cumulativeWeights.Length; i++)
        {
            cumulative += list[i].GetWeight;
            cumulativeWeights[i] = cumulative;
        }
      
        for (i = 0; i < list.Count; i++)
        {
            weightTotal += list[i].GetWeight;
        }
        weightTotal += 1;
        // generating random number in a range of 0 to sum of weights
        int rand = rnd.Next(weightTotal);
       
        // comparing generating number with cumulative weights
        for (i = 0; i < list.Count; i++)
        {
            total += list[i].GetWeight;
            if (cumulativeWeights[i] >= rand)               
                break;
        }
        return list[i].GetName;
    }

    public static void Main()
    {
        Behavior newBehavior = new Behavior();
        string current = "";
        string previous = "";

        List<AnimationData> animationList = new List<AnimationData>();
        animationList.Add(new AnimationData(0, "throwing", 1));
        animationList.Add(new AnimationData(1, "thinking", 1));
        animationList.Add(new AnimationData(2, "looking_around", 1));
        animationList.Add(new AnimationData(3, "whistling", 1));
        animationList.Add(new AnimationData(4, "foot_playing", 1));

        for (int i = 1; i <= 100; i++)
        {
            current = newBehavior.GetRandomWithWeight(animationList);
            if (!current.Equals(previous))
            {
                Console.WriteLine("{0}) Output: {1}", i, current);
            }
            previous = current;

            Console.WriteLine("{0}", newBehavior.GetRandomDirection());
        }
                   
        Console.ReadLine();
    }
}