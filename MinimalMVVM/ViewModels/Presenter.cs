using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MinimalMVVM.Models;

namespace MinimalMVVM.ViewModels
{
    public class Presenter : ObservableObject
    {
        private string _someText;
        private readonly ObservableCollection<string> _history = new ObservableCollection<string>();

        public string SomeText
        {
            get { return _someText; }
            set
            {
                _someText = value;
                RaisePropertyChangedEvent("SomeText");
            }
        }

        public IEnumerable<string> History
        {
            get { return _history; }
        }

        public ICommand UCaseTextCommand
        {
            get { return new DelegateCommand(UCaseText); }
        }

        public ICommand SpaceTextCommand
        {
            get { return new DelegateCommand(SpaceText); }
        }

        private void SpaceText()
        {
            if (string.IsNullOrWhiteSpace(SomeText))
            {
                return;
            }
            else
            {
                AddToHistory(new TextConverter(s => string.Join(" ", s.ToCharArray())).ConvertText(SomeText));
                SomeText = string.Empty;
            }
        }

        private void UCaseText()
        {
            if (string.IsNullOrWhiteSpace(SomeText))
            {
                return;
            }
            else
            {
                AddToHistory(new TextConverter(s => s.ToUpper()).ConvertText(SomeText));
                SomeText = string.Empty;
            }
        }

        private void AddToHistory(string item)
        {
            if (_history.Contains(item))
            {

            }
            else
            {
                _history.Add(item);
            }
        }
    }
}
