

using Pathfinder.Abstraction;
using Pathfinder.Factories;
using System;
using System.Collections.Generic;
namespace Pathfinder
{
    public static class PFContainer
    {
        static readonly Dictionary<Type, Type> _factories = new Dictionary<Type, Type>();
        static PFContainer()
        {
            Register<IHeuristic, HeuristicFactory, HeuristicEnum>();
            Register<IMapGenerator, MapGeneratorFactory, MapGeneratorEnum>();
            Register<IFinder, FinderFactory, FinderEnum>();
            Register<ICrossover, CrossoverFactory, CrossoverEnum>();
            Register<IMutate, MutateFactory, MutateEnum>();
            Register<IFitness, FitnessFactory, FitnessEnum>();
            Register<ISelection, SelectionFactory, SelectionEnum>();
            Register<IRandom, RandomFactory>();
        }

        public static T Resolve<T, TEnum>(TEnum option) where TEnum : struct
            => GetFactory<T, TEnum>().GetImplementation(option);



        public static T Resolve<T>()
           => GetFactory<T>().GetImplementation();



        public static IFactory<T, TEnum> GetFactory<T, TEnum>() where TEnum : struct
        {
            var type = typeof(T);

            if (!_factories.ContainsKey(type))
                throw new Exception($"Cant find {type.Name} factory");

            var fType = _factories[type];
            var factory = Activator.CreateInstance(fType) as IFactory<T, TEnum>;
            return factory;
        }

        public static IFactory<T> GetFactory<T>()
        {
            var type = typeof(T);
            if (!_factories.ContainsKey(type))
                throw new Exception($"Cant find {type.Name} factory without option parameter");

            var fType = _factories[type];
            var factory = Activator.CreateInstance(fType) as IFactory<T>;
            return factory;
        }


        public static void Register<T, TFactory, TEnum>() where TEnum : struct where TFactory : IFactory<T, TEnum>
        {
            _factories.Add(typeof(T), typeof(TFactory));
        }
        public static void Register<T, TFactory>() where TFactory : IFactory<T>
        {
            _factories.Add(typeof(T), typeof(TFactory));
        }
    }
}