using System;
using System.Collections.Generic;
using System.Reflection;

namespace SimpleBlogProject.Core.Helper.TypeHelper
{
    public static class TypeFinder
    {
        public static IEnumerable<Type> FindClassesOfType<T>()
        {
            return FindClassesOfType(typeof(T));
        }

        private static IEnumerable<Type> FindClassesOfType(Type assignTypeFrom)
        {
            return FindClassesOfType(assignTypeFrom, GetAssemblies());
        }

        private static IList<Assembly> GetAssemblies()
        {
            var addedAssemblyNames = new List<string>();
            var assemblies = new List<Assembly>();

            AddAssembliesInAppDomain(addedAssemblyNames, assemblies);

            return assemblies;
        }

        private static void AddAssembliesInAppDomain(List<string> addedAssemblyNames, List<Assembly> assemblies)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!addedAssemblyNames.Contains(assembly.FullName))
                {
                    assemblies.Add(assembly);
                    addedAssemblyNames.Add(assembly.FullName);
                }
            }
        }

        private static IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies)
        {
            var result = new List<Type>();
            try
            {
                foreach (var a in assemblies)
                {
                    Type[] types = null;
                    try
                    {
                        types = a.GetTypes();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    if (types != null)
                    {
                        foreach (var t in types)
                        {
                            if (assignTypeFrom.IsAssignableFrom(t))
                            {
                                if (!t.IsInterface)
                                {
                                    if (t.IsClass && !t.IsAbstract)
                                    {
                                        result.Add(t);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);

                throw fail;
            }
            return result;
        }
    }
}
