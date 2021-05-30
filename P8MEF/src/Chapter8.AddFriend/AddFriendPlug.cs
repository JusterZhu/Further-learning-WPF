using Chapter8.AddFriend.Views;
using Chapter8.Infrastructure.Common.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace Chapter8.AddFriend
{
    [Export(typeof(IPlug))]
    public class AddFriendPlug : IPlug
    {
        private AddFriendView _view;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get => "AddFriendPlug"; }

        /// <summary>
        /// 模块唯一标识
        /// </summary>
        public string UUID { get => "11EDEF73-6D73-42F7-82F8-EE39BBF336FD"; }

        public IView View { get => _view ?? (_view = new AddFriendView()); }

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
