using CommandLine;
using Pathfinder.CLI.CommandParser;
using Pathfinder.CLI.Commands;
using System;

namespace Pathfinder.CLI.UI
{
    public class Program
    {
        public static int Main(string[] args)
        {

#if DEBUG
            Console.WriteLine("Waiting for attach process");
            Console.Read();
#endif

            return Parser.Default
                .ParseArguments<MapGenerationOption, MapViewerOption, FinderOption>(args)
                .MapResult(
                      (MapGenerationOption opt) => MapGenerationCommand.RunMapGeneration(opt),
                      (MapViewerOption opt) => MapViewerCommand.RunMapViewer(opt),
                      (FinderOption opt) => FinderCommand.RunMapFinder(opt),
                      errs => 1
                );
        }
    }


}

