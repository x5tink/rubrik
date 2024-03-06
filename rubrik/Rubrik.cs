using System;
using rubrik.Models;

namespace rubrik
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!, Creating a rubricks cube for you now");
            Cube RubriksCube = new Cube();
            RubriksCube.setDefaultCubeColours();
            Console.WriteLine("For display purposes your cube will me displayed like:");
            Console.WriteLine(@"            Up face
Left face   Front face   Right face  Back face
            Bottom face");

            Console.WriteLine("");
            Console.WriteLine("Your cube currently looks like:");
            RubriksCube.outputCube();

            Console.WriteLine("To rotate your cube please enter the first letter of the Face. This defaults to clockwise, if you wish to rotate clockwise, add an ' when picking a face. ");
            Console.WriteLine("For example F would rotate the front face clockwise, or U' would rotate the upper face anti clockwise, please note it will only recognise the first letter input");
            Console.WriteLine("Go ahead, give it a try!");

            while (true)
            {
                var userInput = Console.ReadLine();

                //find if anticlockwise
                bool clockwise = true;
                if (userInput.Contains("'"))
                {
                    clockwise = false;
                }


                //do rotation
                userInput = userInput.ToUpper();

                switch (userInput[0])
                {
                    case 'U':
                        RubriksCube.RotateFace(RubriksCube.UFace, clockwise);
                        RubriksCube.outputCube();
                        break;
                    case 'L':
                        RubriksCube.RotateFace(RubriksCube.LFace, clockwise);
                        RubriksCube.outputCube();
                        break;
                    case 'F':
                        RubriksCube.RotateFace(RubriksCube.FFace, clockwise);
                        RubriksCube.outputCube();
                        break;
                    case 'R':
                        RubriksCube.RotateFace(RubriksCube.RFace, clockwise);
                        RubriksCube.outputCube();
                        break;
                    case 'B':
                        RubriksCube.RotateFace(RubriksCube.BFace, clockwise);
                        RubriksCube.outputCube();
                        break;
                    case 'D':
                        RubriksCube.RotateFace(RubriksCube.DFace, clockwise);
                        RubriksCube.outputCube();
                        break;
                    default:
                        Console.WriteLine("Sorry i didnt recognise that, please try again.");
                        break;
                }

                //didnt write an exit or reset as jsut restarting is simple enough, but would need some extra validation to catch say 'reset' or 'quit' keywords if i were
            }
        }
    }
}
