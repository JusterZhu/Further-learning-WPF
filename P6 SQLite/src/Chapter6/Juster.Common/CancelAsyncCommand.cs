using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Juster.Common
{
    class CancelAsyncCommand : CommandBase
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();

        private bool _commandExecuting;

        public CancellationToken Token => _cts.Token;

        public void NotifyCommandStarting()
        {
            _commandExecuting = true;
            if (!_cts.IsCancellationRequested)
                return;
            _cts = new CancellationTokenSource();
            RaiseCanExecuteChanged();
        }

        public void NotifyCommandFinished()
        {
            _commandExecuting = false;
            RaiseCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return _commandExecuting && !_cts.IsCancellationRequested;
        }

        protected override void OnExecute(object parameter)
        {
            _cts.Cancel();
            RaiseCanExecuteChanged();
        }
    }
}
