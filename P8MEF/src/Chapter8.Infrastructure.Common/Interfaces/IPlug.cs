using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter8.Infrastructure.Common.Interfaces
{ 
    public interface IPlug
    {
        public IView View { get; }

        public string Name { get; }

        public string UUID { get; }

        void Init();

        void Release();
    }
}
