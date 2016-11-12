using SharpDX;
using SharpDX.Windows;
using SharpDX.DXGI;
using D3D11 = SharpDX.Direct3D11;
using SharpDX.Direct3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evo01.Forms
{
    public class Simulation : IDisposable
    {
        protected RenderForm renderForm;

        protected int Width = 1280;
        protected int Height = 720;

        private D3D11.Device d3dDevice;
        private D3D11.DeviceContext d3dDeviceContext;
        private D3D11.RenderTargetView renderTargetView;
        private SwapChain swapChain;

        public Simulation(string text)
        {
            renderForm = new RenderForm(text);
            renderForm.ClientSize = new System.Drawing.Size(Width, Height);

            InitializeDeviceResources();
        }

        public void Dispose()
        {
            renderTargetView.Dispose();
            swapChain.Dispose();
            d3dDevice.Dispose();
            d3dDeviceContext.Dispose();
            renderForm.Dispose();
        }

        public void Run()
        {
            RenderLoop.Run(renderForm, RenderCallback);
        }

        private void Draw()
        {
            d3dDeviceContext.OutputMerger.SetRenderTargets(renderTargetView);
            d3dDeviceContext.ClearRenderTargetView(renderTargetView, new Color(32, 103, 178));
            swapChain.Present(1, PresentFlags.None);
        }

        protected void RenderCallback()
        {
            Draw();
        }

        protected void InitializeDeviceResources()
        {
            ModeDescription backBufferDesc = new ModeDescription(Width, Height, new Rational(60, 1), Format.R8G8B8A8_UNorm);

            SwapChainDescription swapChainDesc = new SwapChainDescription()
            {
                ModeDescription = backBufferDesc,
                SampleDescription = new SampleDescription(1, 0),
                Usage = Usage.RenderTargetOutput,
                BufferCount = 1,
                OutputHandle = renderForm.Handle,
                IsWindowed = true
            };

            D3D11.Device.CreateWithSwapChain(DriverType.Hardware, D3D11.DeviceCreationFlags.None, swapChainDesc, out d3dDevice, out swapChain);
            d3dDeviceContext = d3dDevice.ImmediateContext;

            using (D3D11.Texture2D backBuffer = swapChain.GetBackBuffer<D3D11.Texture2D>(0))
            {
                renderTargetView = new D3D11.RenderTargetView(d3dDevice, backBuffer);
            }
        }
    }
}
