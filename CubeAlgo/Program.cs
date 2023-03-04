// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please Input");
        var input = GetInput();
        var boxes = GetBoxes(input);
        var cubes = GetCubes(input);
        var result = GetResult(cubes, boxes);
        ShowResult(result);
    }

    static string[] GetInput()
    {
        var input = Console.In.ReadToEnd();
        var splitedInput = input.Split('\r');
        string[] cleanedInput = new string[splitedInput.Length - 1];
        for (int i = 0; i < splitedInput.Length - 1; i++)
        {
            cleanedInput[i] = splitedInput[i].Replace("\n", "");
        }
        return cleanedInput;
    }
    static List<Box> GetBoxes(string[] input)
    {
        var boxes = new List<Box>();
        for (var i = 0; i < input.Length; i++)
        {
            var elements = input[i].Split(" ");
            boxes.Add(new Box(Convert.ToDouble(elements[0]), Convert.ToDouble(elements[1]), Convert.ToDouble(elements[2])));
        }
        return boxes;
    }
    static List<List<Cube>> GetCubes(string[] input)
    {
        List<List<Cube>> cubes = new List<List<Cube>>();
        for (var i = 0; i < input.Length; i++)
        {
            var elements = input[i].Split(" ").ToList();
            var filteredItems = elements.Splice(3, elements.Count - 3);
            var cube = new List<Cube>();
            for (int j = 0; j < filteredItems.Count; j++)
            {
                cube.Add(new Cube(Convert.ToDouble(Math.Pow(2, j)), Convert.ToDouble(filteredItems[j])));
            }
            cubes.Add(cube);

        }
        return cubes;
    }
    static bool IsBoxVolGreaterThanCube(List<Cube> cubes, Box box)
    {
        var cubeVol = cubes.Select(x => x.TotalVolume).Sum();
        return box.Volume > cubeVol ? true : false;
    }
    static List<double> GetResult(List<List<Cube>> cubes, List<Box> boxes)
    {
        List<double> result = new List<double>();
        for (int i = 0; i < boxes.Count; i++)
        {
            if (IsBoxVolGreaterThanCube(cubes[i], boxes[i]))
            {
                result.Add(-1);
            }
            else
            {
                var boxVol = boxes[i].Volume;
                double cubeUsed = 0;
                for (int j = cubes[i].Count - 1; j >= 0; j--)
                {
                    if (boxVol == 0)
                    {
                        break;
                    }
                    else if (boxVol > cubes[i][j].TotalVolume)
                    {
                        cubeUsed += cubes[i][j].NumberOfCubes;
                        boxVol -= cubes[i][j].TotalVolume;
                    }
                    else
                    {
                        var mathFloorReasult = Math.Floor((boxVol) / cubes[i][j].Volume);
                        cubeUsed += mathFloorReasult;
                        boxVol = 0;
                    }
                }
                result.Add(cubeUsed);
            }
        }


        return result;
    }
    static void ShowResult(List<double> list)
    {
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}

public class Box
{
    public Box(double height, double width, double length)
    {
        Height = height;
        Width = width;
        Length = length;
    }

    public double Height { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Volume { get => Height * Width * Length; }
}

public class Cube
{
    public Cube(double size, double numberOfCubes)
    {
        Size = size;
        NumberOfCubes = numberOfCubes;
    }

    public double Size { get; set; }
    public double NumberOfCubes { get; set; }
    public double Volume { get => Math.Pow(Size, 3); }
    public double TotalVolume { get => Volume * NumberOfCubes; }
}

public static class ExtentionFunctions
{
    public static List<T> Splice<T>(this List<T> source, int index, int count)
    {
        var items = source.GetRange(index, count);
        source.RemoveRange(index, count);
        return items;
    }
}