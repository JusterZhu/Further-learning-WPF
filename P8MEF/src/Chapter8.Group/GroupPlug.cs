using Chapter8.Group.Views;
using Chapter8.Infrastructure.Common.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace Chapter8.Group
{
    [Export(typeof(IPlug))]
    public class GroupPlug : IPlug
    {
        private GroupView _view;

        public string Name => "GroupPlug";

        public string UUID => "8A21E64A-7DBC-40FE-ABEB-2E33E57E497E";

        public IView View { get => _view ?? (_view = new GroupView()); }

        public void Init()
        {
            //该业务模块插件初始化的时候需要做的事情，例如加载资源文件
        }

        public void Release()
        {
            //释放该业务模块插件的资源
        }
    }
}
