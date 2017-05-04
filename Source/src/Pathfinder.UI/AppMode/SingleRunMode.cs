using Pathfinder.Abstraction;
using Pathfinder.UI.Abstraction;
namespace Pathfinder.UI.AppMode
{
    public class SingleRunMode : IAppMode
    {
        public void Run()
        {
            var heuristic = PFContainer.Resolve<IHeuristic>();
            var finder = PFContainer.Resolve<IFinder>();
            var generator = PFContainer.Resolve<IMapGenerator>();
            var viewer = PFContainer.Resolve<IViewer>();
            var map = generator.DefineMap();
            viewer.SetFinder(finder);
            viewer.Run(map);
        }
    }
}
