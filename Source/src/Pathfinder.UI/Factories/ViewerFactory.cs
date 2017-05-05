using Pathfinder.Abstraction;
using Pathfinder.UI.Abstraction;
using Pathfinder.UI.Viewer;
using System;
namespace Pathfinder.UI.Factories
{
    public class ViewerFactory : IFactory<IViewer, ViewerEnum>
    {
        public static IViewer GetConsoleViewerImplementation()
         => new ConsoleViewer();
        public static IViewer GetOpenGlViewerImplementation()
            => new OpenGlViewer();
        public IViewer GetImplementation(ViewerEnum option)
            => Decide(option);
        private static IViewer Decide(ViewerEnum option)
        {
            switch (option)
            {
                case ViewerEnum.Console:
                    return GetConsoleViewerImplementation();
                case ViewerEnum.OpenGL:
                    return GetOpenGlViewerImplementation();
            }
            throw new Exception("No viewer selected");
        }
    }
}
