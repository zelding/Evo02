using SharpDX;
using SharpDX.Windows;
using SharpDX.DXGI;
using D3D11 = SharpDX.Direct3D11;
using SharpDX.Direct3D;
using SharpDX.D3DCompiler;
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
        
        private Vector3[] vertices;
        private Vector4[] vertices2;
        private D3D11.Buffer triangleVertexBuffer;

        private D3D11.VertexShader vertexShader;
        private D3D11.PixelShader pixelShader;

        private D3D11.InputElement[] inputElements = new D3D11.InputElement[]
        {
            new D3D11.InputElement("POSITION", 0, Format.R32G32B32_Float, 0)
        };

        private ShaderSignature inputSignature;
        private D3D11.InputLayout inputLayout;

        private Viewport viewport;

        public Simulation(string text)
        {
            renderForm = new RenderForm(text);
            renderForm.ClientSize = new System.Drawing.Size(Width, Height);

            InitializeDeviceResources();
            InitializeShaders();
            InitializeTriangle();
            //InitializeCube();
        }

        public void Dispose()
        {
            inputLayout.Dispose();
            inputSignature.Dispose();
            triangleVertexBuffer.Dispose();
            vertexShader.Dispose();
            pixelShader.Dispose();
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

            d3dDeviceContext.InputAssembler.SetVertexBuffers(0, new D3D11.VertexBufferBinding(triangleVertexBuffer, Utilities.SizeOf<Vector3>(), 0));
            d3dDeviceContext.Draw(vertices.Count(), 0);

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

            viewport = new Viewport(0, 0, Width, Height);
            d3dDeviceContext.Rasterizer.SetViewport(viewport);

            using (D3D11.Texture2D backBuffer = swapChain.GetBackBuffer<D3D11.Texture2D>(0))
            {
                renderTargetView = new D3D11.RenderTargetView(d3dDevice, backBuffer);
            }           
        }

        private void InitializeTriangle()
        {
            vertices = new Vector3[] {
                new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0.0f, 0.0f, 0.5f),
                new Vector3(-0.5f, -0.5f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.5f, -0.5f, 0.0f),
                new Vector3(-0.3f, 0.3f, 0.0f), new Vector3(0.3f, 0.3f, 0.0f), new Vector3(0.0f, -1.0f, 0.0f),
            };

            triangleVertexBuffer = D3D11.Buffer.Create<Vector3>(d3dDevice, D3D11.BindFlags.VertexBuffer, vertices);
        }

        private void InitializeCube()
        {
            vertices = new Vector3[] {
                new Vector3(-1.0f, -1.0f, -0.5f), new Vector3(1.0f, 0.0f, 0.0f), // Front 
                new Vector3(-1.0f,  1.0f, -0.5f), new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3( 1.0f,  1.0f, -1.0f), new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3(-1.0f, -0.5f, -1.0f), new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3( 0.5f,  1.0f, -1.0f), new Vector3(1.0f, 0.0f, 0.0f),
                new Vector3( 1.0f, -1.0f, -1.0f), new Vector3(1.0f, 0.0f, 0.0f),

                new Vector3(-0.5f, -1.0f,  1.0f), new Vector3(0.0f, 1.0f, 0.0f), // BACK 
                new Vector3( 1.0f,  1.0f,  1.0f), new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3(-1.0f,  1.0f,  1.0f), new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3(-1.0f, -1.0f,  1.0f), new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3( 1.0f, -1.0f,  1.0f), new Vector3(0.0f, 1.0f, 0.0f),
                new Vector3( 1.0f,  1.0f,  1.0f), new Vector3(0.0f, 1.0f, 0.0f),

                new Vector3(-1.0f, 1.0f, -1.0f), new Vector3(0.0f, 0.0f, 1.0f), // Top 
                new Vector3(-1.5f, 1.0f,  1.0f), new Vector3(0.0f, 0.0f, 1.0f),
                new Vector3( 1.0f, 1.0f,  1.0f), new Vector3(0.0f, 0.0f, 1.0f),
                new Vector3(-1.0f, 1.0f, -1.0f), new Vector3(0.0f, 0.0f, 1.0f),
                new Vector3( 1.0f, 1.0f,  1.0f), new Vector3(0.0f, 0.0f, 1.0f),
                new Vector3( 1.0f, 1.0f, -1.0f), new Vector3(0.0f, 0.0f, 1.0f),

                new Vector3(-1.0f,-1.0f, -1.0f), new Vector3(1.0f, 1.0f, 0.0f), // Bottom 
                new Vector3( 1.0f,-1.0f,  1.0f), new Vector3(1.0f, 1.0f, 0.0f),
                new Vector3(-1.0f,-1.0f,  1.0f), new Vector3(1.0f, 1.0f, 0.0f),
                new Vector3(-1.0f,-1.0f, -1.0f), new Vector3(1.0f, 1.0f, 0.0f),
                new Vector3( 1.0f,-1.0f, -1.0f), new Vector3(1.0f, 1.0f, 0.0f),
                new Vector3( 1.0f,-1.0f,  1.0f), new Vector3(1.0f, 1.0f, 0.0f),

                new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 0.0f, 1.0f), // Left 
                new Vector3(-1.0f, -1.0f,  1.0f), new Vector3(1.0f, 0.0f, 1.0f),
                new Vector3(-1.0f,  1.0f,  1.0f), new Vector3(1.0f, 0.0f, 1.0f),
                new Vector3(-1.0f, -1.0f, -1.0f), new Vector3(1.0f, 0.0f, 1.0f),
                new Vector3(-1.0f,  1.0f,  1.0f), new Vector3(1.0f, 0.0f, 1.0f),
                new Vector3(-1.0f,  1.0f, -1.0f), new Vector3(1.0f, 0.0f, 1.0f),

                new Vector3( 1.0f, -1.0f, -1.0f), new Vector3(0.0f, 1.0f, 1.0f), // Right 
                new Vector3( 1.0f,  1.0f,  1.0f), new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3( 1.0f, -1.0f,  1.0f), new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3( 1.0f, -1.0f, -1.0f), new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3( 1.0f,  1.0f, -1.0f), new Vector3(0.0f, 1.0f, 1.0f),
                new Vector3( 1.0f,  1.0f,  1.0f), new Vector3(0.0f, 1.0f, 1.0f),
            };

            triangleVertexBuffer = D3D11.Buffer.Create<Vector3>(d3dDevice, D3D11.BindFlags.VertexBuffer, vertices);
        }

        private void InitializeShaders()
        {
            using (var vertexShaderByteCode = ShaderBytecode.CompileFromFile("vertexShader.hlsl", "main", "vs_4_0", ShaderFlags.Debug))
            {
                inputSignature = ShaderSignature.GetInputSignature(vertexShaderByteCode);
                vertexShader = new D3D11.VertexShader(d3dDevice, vertexShaderByteCode);
            }
            using (var pixelShaderByteCode = ShaderBytecode.CompileFromFile("pixelShader.hlsl", "main", "ps_4_0", ShaderFlags.Debug))
            {
                pixelShader = new D3D11.PixelShader(d3dDevice, pixelShaderByteCode);
            }

            d3dDeviceContext.VertexShader.Set(vertexShader);
            d3dDeviceContext.PixelShader.Set(pixelShader);
            d3dDeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;

            inputLayout = new D3D11.InputLayout(d3dDevice, inputSignature, inputElements);
            d3dDeviceContext.InputAssembler.InputLayout = inputLayout;
        }
    }
}
