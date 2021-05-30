using Chapter8.Infrastructure.Common.Interfaces;
using Chapter8.Infrastructure.Common.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Chapter8.ViewModels
{
    public class MainViewModel : BindableBase
    {
        /// <summary>
        /// 插件集合
        /// </summary>
        [ImportMany]
        public List<IPlug> Plugs { get; set; }
        
        private CompositionContainer _container;
        private ObservableCollection<IPlug> _appPlugs;
        private IPlug _currentPlugs;
        private UserControl _view;

        public ObservableCollection<IPlug> AppPlugs 
        {
            get { return _appPlugs; }
            set 
            {
                _appPlugs = value;
                OnPropertyChanged("AppPlugs");
            }
        }

        public IPlug CurrentPlug 
        {
            get { return _currentPlugs; } 
            set 
            { 
                _currentPlugs = value;
                OnPropertyChanged("CurrentPlug");
            }
        }

        public MainViewModel() 
        {
            Composes();
            AppPlugs = new ObservableCollection<IPlug>(Plugs);
            CurrentPlug = AppPlugs.FirstOrDefault();
        }

        public void Composes()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            //初始化该目录下所有复合条件的DLL对象
            var catalog = new DirectoryCatalog(dir);
            //将所有DLL对象进行组装
            _container = new CompositionContainer(catalog);
            //指定最终组装承载的容器对象
            _container.ComposeParts(this);
        }
    }
}
