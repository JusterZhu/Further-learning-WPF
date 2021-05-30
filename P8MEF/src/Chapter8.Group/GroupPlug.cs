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
            //��ҵ��ģ������ʼ����ʱ����Ҫ�������飬���������Դ�ļ�
        }

        public void Release()
        {
            //�ͷŸ�ҵ��ģ��������Դ
        }
    }
}
