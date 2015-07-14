﻿using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace ReactiveRouting
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; private set; }

        public ReactiveCommand<object> NavigateToACommand { get; private set; }
        public ReactiveCommand<object> NavigateToBCommand { get; private set; }
        public ReactiveCommand<object> BackCommand { get; private set; }

        public MainWindowViewModel()
        {
            Router = new RoutingState();

            var canGoBack = this.WhenAnyValue(vm => vm.Router.NavigationStack.Count)
                                .Select(count => count > 0);

            NavigateToACommand =  ReactiveCommand.Create();
            NavigateToBCommand =  ReactiveCommand.Create();
            BackCommand =  ReactiveCommand.Create(canGoBack);

            NavigateToACommand.Subscribe(NavigateToA);
            NavigateToBCommand.Subscribe(NavigateToB);
            BackCommand.Subscribe(NavigateBack);
        }

        public void NavigateBack(object _)
        {
            Router.NavigateBack.Execute(null);
        }

        public void NavigateToA(object _)
        {
            Router.Navigate.Execute(new ViewModelA(this));
        }

        public void NavigateToB(object _)
        {
            Router.Navigate.Execute(new ViewModelB(this));
        }
    }
}