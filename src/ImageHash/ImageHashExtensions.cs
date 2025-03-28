namespace CoenM.ImageHash
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;

    /// <summary>
    /// Extension methods for IImageHash.
    /// </summary>
    public static class ImageHashExtensions
    {
        /// <summary>Calculate the hash of the image (stream) using the hashImplementation.</summary>
        /// <param name="hashImplementation">HashImplementation to calculate the hash.</param>
        /// <param name="stream">Stream should 'contain' raw image data.</param>
        /// <returns>hash value.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="hashImplementation"/> or <paramref name="stream"/> is <c>null</c>.</exception>
        public static ulong Hash(this IImageHash hashImplementation, Stream stream)
        {
            if (hashImplementation == null)
            {
                throw new ArgumentNullException(nameof(hashImplementation));
            }

            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            // Assuming 'imageStream' is your input stream
            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            byte[] imageData = memoryStream.ToArray();
            Mat mat = new Mat();
            CvInvoke.Imdecode(imageData, ImreadModes.Color, mat);

            return hashImplementation.Hash(mat);
        }
    }
}
