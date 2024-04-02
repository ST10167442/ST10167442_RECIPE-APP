using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Recipe App!");

        Recipe recipe = new Recipe();
        bool continueInput = true;

        while (continueInput)
        {
            Console.WriteLine("\nEnter the details for a new recipe:");

            // Enter the number of ingredients with error handling
            int ingredientCount;
            do
            {
                Console.WriteLine("Enter the number of ingredients:");
            } while (!int.TryParse(Console.ReadLine(), out ingredientCount) || ingredientCount <= 0);

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1}:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter quantity for {name}:");
                int quantity;
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer:");
                }

                Console.WriteLine($"Enter unit of measurement for {name}:");
                string unit = Console.ReadLine();

                recipe.AddIngredient(name, quantity, unit);
            }

            // Enter the number of steps with error handling
            int stepCount;
            do
            {
                Console.WriteLine("Enter the number of steps:");
            } while (!int.TryParse(Console.ReadLine(), out stepCount) || stepCount <= 0);

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipe.DisplayRecipe();

            Console.WriteLine("Do you want to scale the recipe? (Enter factor: 0.5, 2, or 3)");
            double factor;
            while (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
            {
                Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3:");
            }
            recipe.ScaleRecipe(factor);

            Console.WriteLine("Do you want to reset ingredient quantities? (Y/N)");
            string reset = Console.ReadLine();
            if (reset.ToUpper() == "Y")
                recipe.ResetQuantities();

            Console.WriteLine("Do you want to clear all data and enter a new recipe? (Y/N)");
            string clear = Console.ReadLine();
            if (clear.ToUpper() == "N")
                continueInput = false;
            else
                recipe.ClearRecipe();
        }

        Console.WriteLine("\nThank you for using the Recipe App!");
    }
}

internal class Recipe
{
    private string[] ingredients;
    private int[] quantities;
    private string[] units;
    private string[] steps;

    public Recipe()
    {
        ingredients = new string[0];
        quantities = new int[0];
        units = new string[0];
        steps = new string[0];
    }

    public void AddIngredient(string ingredient, int quantity, string unit)
    {
        Array.Resize(ref ingredients, ingredients.Length + 1);
        Array.Resize(ref quantities, quantities.Length + 1);
        Array.Resize(ref units, units.Length + 1);

        int index = ingredients.Length - 1;
        ingredients[index] = ingredient;
        quantities[index] = quantity;
        units[index] = unit;
    }

    public void AddStep(string step)
    {
        Array.Resize(ref steps, steps.Length + 1);
        int index = steps.Length - 1;
        steps[index] = step;
    }

    public void DisplayRecipe()
    {
        Console.WriteLine("\nRecipe:");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"{ingredients[i]} - {quantities[i]} {units[i]}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    public void ScaleRecipe(double factor)
    {
        for (int i = 0; i < quantities.Length; i++)
        {
            quantities[i] = (int)(quantities[i] * factor);
        }
    }

    public void ResetQuantities()
    {
        // Implement if necessary
    }

    public void ClearRecipe()
    {
        ingredients = new string[0];
        quantities = new int[0];
        units = new string[0];
        steps = new string[0];
    }
}