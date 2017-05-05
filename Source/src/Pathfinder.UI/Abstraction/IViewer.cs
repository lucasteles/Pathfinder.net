using Pathfinder.Abstraction;
namespace Pathfinder.UI.Abstraction
{
    public interface IViewer
    {
        void Run(IMap map, IHeuristic h);
        void SetFinder(IFinder finder);
    }
}
