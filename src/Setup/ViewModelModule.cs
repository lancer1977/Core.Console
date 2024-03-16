using PolyhydraGames.Core.Console.Interfaces;
using PolyhydraGames.Extensions;
using System.Diagnostics;
using System.Reflection;

namespace PolyhydraGames.Core.Console.Setup;

public static class ViewModelModule
{
    public static IServiceCollection RegisterViewModelsAndPages(this IServiceCollection app,
        params Assembly[] assembies)
    {
        foreach (var item in assembies)
            app
                .RegisterViewModels(item)
                .RegisterPages(item);

        return app;
    }

    public static void RegisterViewFactory(this IHost host, params Assembly[] assembies)
    {
        ViewFactoryRegistration(assembies);
    }

    public static IEnumerable<Type> Pages(this Assembly assembly)
    {
        return assembly.CreatableTypes().EndingWith("Page");
    }

    public static IEnumerable<Type> ViewModels(this Assembly assembly)
    {
        return assembly.CreatableTypes().EndingWith("ViewModel");
    }

    public static IServiceCollection RegisterViewModels(this IServiceCollection services, Assembly assembly)
    {
        var vms = ViewModels(assembly);
        foreach (var item in vms)
        {
            if (item.Name.Contains("DatabaseLoader")) Debug.WriteLine(item.Name);
            services.AddTransient(item);
            var interfaces = item.GetInterfaces().Where(x => x.Name.Contains("ViewModel"));
            foreach (var @interface in interfaces)
            {
                services.AddTransient(@interface, item);
            }

        }

        return services;
    }


    public static IServiceCollection RegisterPages(this IServiceCollection services, Assembly assembly)
    {
        foreach (var item in Pages(assembly)) services.AddTransient(item);
        return services;
    }

    public static void ViewFactoryRegistration(params Assembly[] assembies)
    {
        var pageList = new List<Type>();
        var viewModelList = new List<Type>();
        foreach (var item in assembies)
        {
            pageList.AddRange(item.Pages());
            viewModelList.AddRange(item.ViewModels());
        }

        PairMVVMInterfaces(pageList, viewModelList.ToArray());
    }

    private static void PairMVVMInterfaces(IEnumerable<Type> pages, IEnumerable<Type> viewModels)
    {
        var factory = IOC.IOC.Get<IViewFactoryAsync>();
        foreach (var page in pages)
        {

            var prefix = page.GetTypeInfo().Name.Replace("Page", "");
            var viewModel = viewModels.FirstOrDefault(i => i.GetTypeInfo().Name.Replace("ViewModel", "") == prefix);
            if (viewModel == null)
            {
                Debug.WriteLine(page.Name);
                continue;
                throw new Exception($"No viewmodel found for type of {page.Name}");
            }

            var iviewmodel = typeof(IViewModelAsync);
            var implementedInterfaces = viewModel
                .GetInterfaces()
                .Where(p => iviewmodel.IsAssignableFrom(p))
                .Except(typeof(IViewModelAsync));
            foreach (var t in implementedInterfaces)
            {
                Debug.WriteLine($"Registring {t.Name} to {page.Name}");
                factory.Register(t, page);
            }

            factory.Register(viewModel, page);
        }
    }
}