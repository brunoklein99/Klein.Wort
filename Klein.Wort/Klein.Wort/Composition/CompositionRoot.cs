using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Klein.Wort.ViewModel;

namespace Klein.Wort.Composition
{
    public class CompositionRoot : IDisposable
    {
        private WindsorContainer _container;

        public CompositionRoot()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<IWindow>().ImplementedBy<MainWindow>());
            _container.Register(Classes.FromAssemblyInThisApplication().BasedOn<ViewModelBase>());
            _container.Register(Component.For<IWordTranslationProvider>().ImplementedBy<FakeWordTranslationProvider>());
            _container.Register(Component.For<IWordTranslationManager>().ImplementedBy<FakeWordTranslationManager>());
            _container.Register(Component.For<ITimer>().ImplementedBy<DefaultTimer>());
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Dispose()
        {
            if (_container != null)
            {
                _container.Dispose();
                _container = null;
            }
        }
    }
}