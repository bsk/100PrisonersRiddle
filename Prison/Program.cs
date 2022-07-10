// https://www.youtube.com/watch?v=iSNsgj1OCLA

using System.Linq;

var watch = System.Diagnostics.Stopwatch.StartNew();

Console.WriteLine("Enter the number of prisoners (even number, e.g. 100)");

var prisonersCount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the number of loops (e.g. 100000)");

var loopsCount = Convert.ToInt32(Console.ReadLine());

var rand = new Random();

var successes = 0;

var failures = 0;

for (var i = 0; i < loopsCount; i++)
{
    var randomBoxes = Enumerable.Range(1, prisonersCount).OrderBy(i => rand.Next()).ToArray();

    // for (var i = 0; i < prisonersCount; i++)
    //     Console.WriteLine(randomBoxes[i]);

    var prisonerSuccess = new bool[prisonersCount];

    for (var prisonerNumber = 1; prisonerNumber <= prisonersCount; prisonerNumber++)
    {
        var boxToOpen = prisonerNumber;

        var boxesOpen = 0;

        bool thisPrisonerSuccess;
        do
        {
            var numberInBox = randomBoxes[boxToOpen - 1];

            boxesOpen++;

            // Console.WriteLine(
            //     $"Prisoner {prisonerNumber} opens box {boxToOpen} and sees number {numberInBox}, this was his box {boxesOpen}");

            boxToOpen = numberInBox;

            thisPrisonerSuccess = numberInBox == prisonerNumber;

            prisonerSuccess[prisonerNumber - 1] = thisPrisonerSuccess;
        } while (boxesOpen != prisonersCount / 2 && !thisPrisonerSuccess);
    }

    // Console.WriteLine("[{0}]", string.Join(", ", prisonerSuccess));

    var success = prisonerSuccess.All(x => x);

    if (success)
    {
        // Console.WriteLine("Success!");
        successes++;
    }
    else
    {
        // Console.Write("List of failures: ");
        // for (var i = 0; i < prisonerSuccess.Length; i++)
        // {
        //     var succ = prisonerSuccess[i];
        //     if (!succ)
        //     {
        //         Console.Write((i + 1) + " ");
        //     }
        // }

        failures++;
    }
}

Console.WriteLine($"\nSuccesses {successes}, failures {failures}\n");

watch.Stop();
Console.WriteLine($"Took {watch.Elapsed.TotalSeconds} sec to run");