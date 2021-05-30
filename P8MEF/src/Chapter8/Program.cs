using Chapter8.Infrastructure.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8
{
    public class Program
    {
        [ImportMany]
        public List<IPlug> Plugs { get; set; }

        private static CompositionContainer _container;

        [STAThread]
        static void Main(string[] args)
        {
            var program = new Program();
            program.Composes();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Composes()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var catalog = new DirectoryCatalog(dir);
            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }
    }
}
