class Program
{
    static void Main()
    {
        var left = new List<int>();
        var right = new List<int>();

        using var sr = new StreamReader("input.txt");
        string line;
        while ((line = sr.ReadLine()!) != null)
        {

            var parts = line.Split(' ');
            left.Add(int.Parse(parts[0]));
            right.Add(int.Parse(parts[parts.Length - 1]));
        }
        left.Sort();
        right.Sort();
        int diff = 0;
        int similarity = 0;
        for (int i = 0; i < left.Count; i++)
        {
            diff += Math.Abs(left[i] - right[i]);
            if (right.Contains(left[i]))
            {
                int equally = 0;
                foreach (int n in right)
                {
                    if (left[i] == n) equally++;
                }

                similarity += (left[i] * equally);
            }
        }
        Console.WriteLine(diff);
        Console.WriteLine(similarity);
        Console.ReadKey();
    }
}