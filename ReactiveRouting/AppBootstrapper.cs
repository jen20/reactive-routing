﻿using ReactiveUI;
using Splat;

namespace ReactiveRouting
{
    public class AppBootstrapper
    {
        public void Run()
        {
            RegisterViews();
            var vm = MakeAndRegisterMainViewModel();
            var view = new MainWindowView {ViewModel = vm};
            view.Show();
        }

        private MainWindowViewModel MakeAndRegisterMainViewModel()
        {
            var vm = new MainWindowViewModel();
            Locator.CurrentMutable.RegisterConstant(vm, typeof(IScreen));
            return vm;
        }

        private void RegisterViews()
        {
            var ioc = Locator.CurrentMutable;

            ioc.Register(() => new ViewA(), typeof (IViewFor<ViewModelA>));
            ioc.Register(() => new ViewB(), typeof(IViewFor<ViewModelB>));
        }
    }
}