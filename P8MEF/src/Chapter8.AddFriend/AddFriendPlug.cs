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
        /// ģ������
        /// </summary>
        public string Name { get => "AddFriendPlug"; }

        /// <summary>
        /// ģ��Ψһ��ʶ
        /// </summary>
        public string UUID { get => "11EDEF73-6D73-42F7-82F8-EE39BBF336FD"; }

        public IView View { get => _view ?? (_view = new AddFriendView()); }

        public void Init()
        {
            //��ҵ��ģ������ʼ����ʱ����Ҫ�������飬���������Դ�ļ�
        }

        public void Release()
        {
            //�ͷŸ�ҵ��ģ��������Դ
        }
    }
}
