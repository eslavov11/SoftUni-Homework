namespace FlyweightGame.UI
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public sealed class AssetLoader
    {
        private static readonly AssetLoader instance = new AssetLoader();
        private static readonly Dictionary<AssetType, ImageSource> images = new Dictionary<AssetType, ImageSource>();

        private AssetLoader()
        {
        }

        public static AssetLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public Image GetImage(AssetType type)
        {
            return new Image()
            {
                Source = this.LoadImage(type)
            };
        }

        private ImageSource LoadImage(AssetType type)
        {
            string path = string.Empty;

            switch (type)
            {
                case AssetType.Reaper:
                    path = AssetPaths.ReaperImage;
                    break;
                default: 
                    throw new ArgumentException("Unsupported asset type.");
            }

            if (images.ContainsKey(type))
            {
                return images[type];
            }

            var src = new Uri(path, UriKind.Relative);

            images[type] = BitmapFrame.Create(src);

            return images[type];
        }
    }
}
