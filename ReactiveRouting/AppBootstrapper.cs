using ReactiveUI;

namespace ReactiveRouting
{
    public class AppBootstrapper
    {
        public void Run()
        {
            RegisterViews();
            var vm = new MainWindowViewModel();
            var view = new MainWindowView {ViewModel = vm};
            view.Show();
        }

        private void RegisterViews()
        {
            var ioc = RxApp.MutableResolver;

            ioc.Register(() => new ViewA(), typeof (IViewFor<ViewModelA>));
            ioc.Register(() => new ViewB(), typeof(IViewFor<ViewModelB>));
        }
    }
}