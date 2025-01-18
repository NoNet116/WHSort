using WHSort;

namespace WHCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string pathfile = Path.Combine(DirectoryExtension.GetSolutionRoot(), filename);

            var text = GetText(pathfile);

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                        
            var words = noPunctuationText.Split([" ", "\n\n", "\n"], StringSplitOptions.RemoveEmptyEntries);
           
            Dictionary<string, int> samewords = [];

            foreach (var word in words)
            {
                if (samewords.ContainsKey(word))
                {
                    samewords[word]++;
                }
                else
                {
                    samewords.Add(word, 1);
                }
            }

            var sortedsamewords = samewords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int position = 1;
            foreach (var word in sortedsamewords.Take(10))
                Console.WriteLine($"{position++:D3} {word.Value:D4} {word.Key}");
           
        }

        static string GetText(string pathfile)
        {
            using var stream = new StreamReader(pathfile);
            return stream.ReadToEnd();
        }
    }
}