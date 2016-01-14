namespace FlyweightGame
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using FlyweightGame.GameObjects;
    using FlyweightGame.UI;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            var canvas = this.FindName("canvas") as Canvas;
            int width = (int) canvas.Width;
            int height = (int) canvas.Height;

            var assetLoader = AssetLoader.Instance;
            var renderer = new Renderer(canvas, assetLoader);

            var randomGenerator = new Random();
            int x, y;
            for (int i = 0; i < 100000; i++)
            {
                x = randomGenerator.Next(0, width);
                y = randomGenerator.Next(0, height);

                renderer.Render(new Reaper(x, y));
            }  
        }
    }
}
