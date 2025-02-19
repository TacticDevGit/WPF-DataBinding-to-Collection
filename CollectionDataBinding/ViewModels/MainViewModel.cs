using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CollectionDataBinding.ViewModels
{
    public class MainViewModel
    {

        public List<string> Letters { get; set; }

        public ICommand MoveNextCommand { get; set; }

        public ICommand MovePreviousCommand { get; set; }


        public ICollectionView  View { get; set; }

        public MainViewModel()
        {
            Letters = new List<string>() { "A", "B", "C", "D", "E", };
            View = CollectionViewSource.GetDefaultView(Letters);

            MoveNextCommand = new RelayCommand(CanMoveNext, MoveNext);

            MovePreviousCommand = new RelayCommand(CanMovePrevious, MovePreivous);



        }

        private void MovePreivous(object obj)
        {
            View.MoveCurrentToPrevious();
        }

        private bool CanMovePrevious(object obj)
        {
            return View.CurrentPosition > 0;
        }



        private void MoveNext(object obj)
        {
            View.MoveCurrentToNext();
        }

        private bool CanMoveNext(object obj)
        {
          return  View.CurrentPosition < Letters.Count - 1;
        }
    }
}
