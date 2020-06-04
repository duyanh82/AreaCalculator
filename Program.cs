using System;

namespace PST1
{
    /// <summary> This class is used to calculate the area of several shapes </summary>
    /// <student_name> Anh Nguyen Dac Duy </student_name>
    /// <student_id> 10603280 </student_id>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWELCOME TO THE AREA CALCULATOR!\n***");
            double option = 0;
            // Put the choices and calculations in a While Loop
            while (option != 4) {
                Menu(); 
                // Tell the user to choose a shape in a menu to calculate its area
                option = GetUserNum(
                    prompt: "Select an option: ", 
                    min: 1, 
                    max: 4, 
                    wholeNumber: true,
                    inclusive: true);
                Console.WriteLine();
                // And run accordingly
                if      (option == 1)  { CircleArea();    }
                else if (option == 2)  { RectangleArea(); }
                else if (option == 3)  { PolygonArea();   }
            }
            // If user chooses 4. Quit, then...
            Console.WriteLine("\n=================================\nGoodbyeee !");
            Console.WriteLine("=================================\n\n\n\n\n");
            // Wait for Enter to close the terminal
            Console.ReadLine();
        }

        /// <summary>
        /// A method to print out a menu of options
        /// </summary>
        static void Menu() {Console.WriteLine("\nMain menu:\n   1) Circle\n   2) Rectangle\n   3) Polygon\n   4) Quit\n"); }

        const double pi = 3.14159;

        /// <summary>
        /// A method to calculate the area of a circle
        /// </summary>
        static void CircleArea() {
            // Tell the user to input radius
            double radius = GetUserNum(
                prompt: "Enter the radius: ", 
                min: 0);
            // Calculate its area
            double area = pi * Math.Pow(radius, 2);
            // Print out that area
            Console.WriteLine($"The area is {area:F2}");
            Console.WriteLine("--------------------------------");
        }

        /// <summary>
        /// A method to calculate the area of a rectangle
        /// </summary>
        static void RectangleArea() {
            // Tell the user to input the length of 2 sides
            double side1 = GetUserNum(
                prompt: "Enter the first side length: ", 
                min: 0);
            double side2 = GetUserNum(
                prompt: "Enter the second side length: ", 
                min: 0);
            // Calculate its area
            double area = side1 * side2;
            // Print out that area
            Console.WriteLine($"The area is {area:F2}");
            Console.WriteLine("--------------------------------");            
        }

        /// <summary>
        /// A method to calculate the area of a polygon
        /// </summary>
        static void PolygonArea() {
            // Tell the user to input the number of sides and the side length
            double sideNum = GetUserNum(
                prompt: "Enter the number of sides: ",
                min: 3,
                wholeNumber: true, 
                inclusive: true);
            double sideLength = GetUserNum(
                prompt: "Enter the side length: ",
                min: 0);
            // Calculate its area
            double area = (Math.Pow(sideLength, 2) * sideNum) / 4 / Math.Tan(pi/sideNum);
            // Print out that area
            Console.WriteLine($"The area is {area:F2}");
            Console.WriteLine("--------------------------------");
        }
        
        /// <summary>
        /// This method returns a double that follows a set of pre-appointed rules 
        /// </summary>
        /// <param name="prompt"> Tell the user what to input </param>
        /// <param name="min"> The minimum value user can input </param>
        /// <param name="max"> The maximum value user can input </param>
        /// <param name="wholeNumber"> Accept whole number only or not </param>
        /// <param name="inclusive"> Accept the maximum/minumum value as mentioned above or not </param>
        /// <returns> Return the input if it satisfies all the requirements </returns>
        static double GetUserNum(
            string prompt = "Enter a number: ", 
            double min = double.MinValue,
            double max = double.MaxValue,
            bool wholeNumber = false,
            bool inclusive = false) {
            
            bool valid = false;
            double userNum = 0;
            // A do-while loop to get an input until that input is valid
            while (!valid) {
                // Announce the user what to input
                Console.Write(prompt);
                try { 
                    // If the input is not numeric, 
                    // the program directs itself to catch error and get input again
                    userNum = double.Parse(Console.ReadLine());
                    // Check the limits if it is inclusive
                    if (inclusive == false && !(userNum < max)) {
                        Console.WriteLine($"Input must be < {max}! \n");
                    } 
                    else if (inclusive == false && !(userNum > min)) {
                        Console.WriteLine($"Input must be > {min}! \n");
                    }
                    // Check the limits if it is not inclusive
                    else if (!(userNum <= max)) {
                        Console.WriteLine($"Input must be <= {max}! \n");
                    }
                    else if (!(userNum >= min)) {
                        Console.WriteLine($"Input must be >= {min}! \n");
                    } 
                    // Check whether it is a whole number or not
                    else if (wholeNumber == true && (int)userNum != userNum) {
                        Console.WriteLine("Input must be a whole number! \n");
                    } 
                    // If everything is ok, set valid to True to return the value.
                    else {
                        valid = true;
                    }
                }
                catch (FormatException) {
                    Console.WriteLine("Input must be numeric! \n");
                }
            } 
            return userNum;
        }
    }
}

