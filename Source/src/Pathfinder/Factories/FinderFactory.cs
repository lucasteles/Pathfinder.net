using Pathfinder.Abstraction;
using Pathfinder.Finders;
using System;
namespace Pathfinder.Factories
{
    public class FinderFactory : IFactory<IFinder, FinderEnum>
    {
        public static IFinder GetAStarImplementation()
            => new AStarFinder();

        public static IFinder GetBFSImplementation()
            => new BestFirstSearchFinder();

        public static IFinder GetIDAStarImplementation()
            => new IDAStarFinder();

        public static IFinder GetDijkstraImplementation()
            => new DijkstraFinder();

        // public static IFinder GetGAImplementation() => new GAFinder();


        public IFinder GetImplementation(FinderEnum option)
            => Decide(option);


        private static IFinder Decide(FinderEnum option)
        {

            switch (option)
            {
                case FinderEnum.AStar:
                    return GetAStarImplementation();
                case FinderEnum.BestFirstSearch:
                    return GetBFSImplementation();
                case FinderEnum.IDAStar:
                    return GetIDAStarImplementation();
                case FinderEnum.Dijkstra:
                    return GetDijkstraImplementation();
                    //  case FinderEnum.GA:
                    // return GetGAImplementation(allowDiagonal);
            }
            throw new Exception("No finder selected");
        }
    }
}