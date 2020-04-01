using System;
using System.Collections.Generic;

namespace mars_rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = GetInput();            
            
            foreach (var input in userInput.rovers)
            {
                var position = input.position;
                foreach(var instruction in input.instructions)
                {
                    switch (instruction)
                    {
                        case 'L':
                            {
                                switch (position[4])
                                {
                                    case 'N':
                                        position = position[0] + " " + position[2] + " " + "W";
                                        break;
                                    case 'E':
                                        position = position[0] + " " + position[2] + " " + "N";
                                        break;
                                    case 'S':
                                        position = position[0] + " " + position[2] + " " + "E";
                                        break;
                                    case 'W':
                                        position = position[0] + " " + position[2] + " " + "S";
                                        break;
                                }
                                break;
                            }
                        case 'R':
                            {
                                switch (position[4])
                                {
                                    case 'N':
                                        position = position[0] + " " + position[2] + " " + "E";
                                        break;
                                    case 'E':
                                        position = position[0] + " " + position[2] + " " + "S";
                                        break;
                                    case 'S':
                                        position = position[0] + " " + position[2] + " " + "W";
                                        break;
                                    case 'W':
                                        position = position[0] + " " + position[2] + " " + "N";
                                        break;
                                }
                                break;
                            }
                        case 'M':
                            {
                                switch (position[4])
                                {
                                    case 'N':
                                        position = position[0] + " " + (int.Parse(position[2].ToString()) + 1).ToString() + " " + position[4];
                                        break;
                                    case 'E':
                                        position = (int.Parse(position[0].ToString()) + 1).ToString() + " " + position[2] + " " + position[4];
                                        break;
                                    case 'S':
                                        position = position[0] + " " + (int.Parse(position[2].ToString()) - 1).ToString() + " " + position[4];
                                        break;
                                    case 'W':
                                        position = (int.Parse(position[0].ToString()) - 1).ToString() + " " + position[2] + " " + position[4];
                                        break;
                                }
                                break;
                            }
                    }
                }
                
                Console.WriteLine(position);
            }
        }

        private static (string plateau, List<(string position, string instructions)> rovers) GetInput()
        {
            var rovers = new List<(string, string)>();

            Console.WriteLine("Please enter upper-right coordinates of the plateau");
            var plateau = Console.ReadLine();

            var gatheringData = true;
            while (gatheringData)
            {
                Console.WriteLine("Please enter start position");
                var position = Console.ReadLine();

                Console.WriteLine("Please give instructions");
                var instructions = Console.ReadLine();

                rovers.Add((position, instructions));

                Console.WriteLine("Are you finished yes/no");
                gatheringData = Console.ReadLine() == "no";
            }

            return (plateau, rovers);
        }
    }
}
