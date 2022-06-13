﻿using CefSharp.Puppeteer.Transport;
using System;
using System.Threading.Tasks;

namespace CefSharp.OutOfProcess.WinForms
{
    public class OutOfProcessConnectionTransport : IConnectionTransport
    {
        public int BrowserId { get; }
        public bool IsClosed { get; private set; }
        public OutOfProcessHost OutOfProcessHost { get; }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public OutOfProcessConnectionTransport(int browserId, OutOfProcessHost outOfProcessHost)
        {
            BrowserId = browserId;
            OutOfProcessHost = outOfProcessHost;
        }

        void IDisposable.Dispose()
        {
            
        }

        public void InvokeMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        }

        public Task SendAsync(string message)
        {
            return OutOfProcessHost.SendDevToolsMessage(BrowserId, message);
        }

        public void StopReading()
        {
            
        }
    }
}
