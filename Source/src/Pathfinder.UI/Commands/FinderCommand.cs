using Pathfinder.CLI.Abstraction;
using Pathfinder.CLI.CommandParser;
using Pathfinder.CLI.Factories;
using Pathfinder.CLI.Viewer;
using Pathfinder.Factories;
using System;
using System.IO;

namespace Pathfinder.CLI.Commands
{
    public class FinderCommand
    {
        public static int RunMapFinder(FinderOption option)
        {

            if (option.Finder == FinderEnum.GA)
            {
                Console.WriteLine("use run-ga for genetic algorithm");
                return 1;
            }

            if (!File.Exists(option.MapFileName))
            {
                Console.WriteLine("map not found");
                return 1;
            }

            var map = MapGeneratorFactory
                        .GetFileMapGeneratorImplementation(option.MapFileName)
                        .DefineMap();


            var finder = (new FinderFactory()).GetImplementation(option.Finder);
            var heuristic = (new HeuristicFactory()).GetImplementation(option.Heuristic);

            if (!option.NoShowSteps)
            {
                var viewer =
                    option.Window ?
                        ViewerFactory.GetOpenGlViewerImplementation(option.BlockSize)
                    : ViewerFactory.GetConsoleViewerImplementation();

                viewer.SetFinder(finder);
                viewer.Run(map, heuristic);
            }
            else
            {
                if (finder.Find(map, heuristic))
                {
                    var path = map.GetPath();

                    AbstractViewer.ShowEndLog(finder, path, new Pathfinder.Abstraction.FinderEventArgs
                    {
                        Finded = true,
                        GridMap = map,
                        ExpandedNodesCount = map.GetMaxExpandedNodes(),
                        PassedTimeInMs = finder.GetProcessedTime(),
                        Step = 0
                    });

                    var result = FileTool.GetTextRepresentation(map, false, path);

                    if (!option.Window)
                        Console.WriteLine(result);
                    else
                        MapViewWindow.OpenGlWindow(result, option.BlockSize);
                }
                else
                    Console.WriteLine("Cant find a path");
            }



            return 0;
        }
    }
}

