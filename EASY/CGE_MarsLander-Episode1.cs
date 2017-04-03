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
    const int MAX_POWER = 4;
    const float gravity = 3.711F;

    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
        
            Console.Error.WriteLine(landX + " " + landY);
        }
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).
            
            Console.Error.WriteLine("{0} {1} {2} {3} {4} {5} {6}", X, Y, hSpeed, vSpeed, fuel, rotate, power);
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            if(Y <= HeightForZero((float)vSpeed - gravity, power)){
                power = NextPowerSpeedDown((float)vSpeed, power);
            }
            else if(power > 0){
                power--;
            }
            // 2 integers: rotate power. rotate is the desired rotation angle (should be 0 for level 1), power is the desired thrust power (0 to 4).
            Console.WriteLine("{0} {1}", rotate, power);
        }
    }

    static int HeightForZero(float vSpeed, int power){
        float height = 0;
        while((int)vSpeed != 0){
            power = NextPowerSpeedDown(vSpeed, power);
            vSpeed += (float)power - gravity;
            height -= vSpeed;
        }
        Console.Error.WriteLine("need {0}m", height);
        return (int)Math.Round(height);
    }

    static int NextPowerSpeedDown(float vSpeed, int power){
        if(vSpeed < 0 && power < MAX_POWER){
            power++;
        }
        else if(vSpeed > 0 && power > 0){
            power--;
        }
        return power;
    }

}