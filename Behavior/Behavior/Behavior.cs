using System;
using System.Collections.Generic;

public class Behavior
{
    public static void Main()
    {
        AnimationData animationData = new AnimationData();

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
            current = animationData.GetRandomWithWeight(animationList);
            if (!current.Equals(previous))
            {
                Console.WriteLine("{0}) Output: {1}", i, current);
            }
            previous = current;
        }
                   
        Console.ReadLine();
    }
}