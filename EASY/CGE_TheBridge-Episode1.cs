using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static int maxspeed;
    static void Main(string[] args)
    {
        int road = int.Parse(Console.ReadLine()); // the length of the road before the gap.
        int gap = int.Parse(Console.ReadLine()); // the length of the gap.
        int platform = int.Parse(Console.ReadLine()); // the length of the landing platform.

        Console.Error.WriteLine("road {0} gap {1} platform {2}", road, gap, platform);
        MaxSpeed(platform);
        string action = "";
        int coordNext;
        int remaining = road - 1;
        int waitTiming = 0;
        bool flg = true;

        // game loop
        while (true)
        {
            int speed = int.Parse(Console.ReadLine()); // the motorbike's speed.
            int coordX = int.Parse(Console.ReadLine()); // the position on the road of the motorbike.
            coordNext = coordX + speed;
            Console.Error.WriteLine("remaining {0} speed {1}", remaining, speed);
            if(waitTiming == 0) waitTiming = WhetherWait(speed, remaining, gap);

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Console.Error.WriteLine("road+gap {0} coordNext {1}", road + gap, coordNext);
            Console.Error.WriteLine("coordX {0} (road+gap) {1} platform {2} forStop {3}", 
            coordX, road + gap, platform, DistanceForStop(speed + 1));
            if(coordX > (road + gap - 1) || platform < DistanceForStop(speed)) action = "SLOW";
            else if((road + gap - 1) < coordNext) action = "JUMP";
            else if(flg && speed == waitTiming){
                action = "WAIT";
                flg = false;
            }
            else if(AvailableSpeedUp(speed, remaining, gap, platform)) action = "SPEED";
            else if((remaining % speed) == 0 || ((remaining % speed) + gap) < speed) action = "WAIT";
            else action = "SLOW";

            switch (action)
            {
                case "SLOW": speed--; break;
                case "SPEED": speed++; break;
            }
            remaining -= speed;

            // A single line containing one of 4 keywords: SPEED, SLOW, JUMP, WAIT.
            Console.WriteLine(action);
        }
    }

    static int DistanceForStop(int speed){
        int distance = 0;
        for(int i = 1; i < speed; i++){
            distance += i;
        }
        return distance;
    }

    static bool AvailableSpeedUp(int speed, int remaining, int gap, int platform){
        speed++;
        Console.Error.WriteLine("available?");
        if(remaining < speed || DistanceForStop(speed) >= platform) return false;
        remaining += gap + platform;
        Console.Error.WriteLine("remaining " + remaining);
        remaining -= speed;
        return DistanceForStop(speed) <= remaining;
    }

    static void MaxSpeed(int platform){
        int i = 0;
        while(DistanceForStop(++i) <= platform){}
        i--;
        Console.Error.WriteLine("maxspeed " + i);
        maxspeed = i;
    }

    static int WhetherWait(int speed, int remaining, int gap){
        int mode = speed < maxspeed ? 0 : 1;
        int sum = 0;
        if(mode == 0){
            while((sum + speed) <= remaining){
                if(speed < maxspeed) speed++;
                sum += speed;
                Console.Error.WriteLine("sum " + sum + " speed " + speed);
            }
            Console.Error.WriteLine(remaining - sum);
        }
        else{
            while((sum + speed) <= remaining){
                if(speed > gap + 1) speed--;
                sum += speed;
                Console.Error.WriteLine("sum " + sum + " speed " + speed);
            }
        }
        return remaining - sum != 0 ? remaining - sum : -1;
    }
}