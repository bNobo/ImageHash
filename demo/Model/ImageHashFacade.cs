namespace Demo.Model
{
    using System;
    using CoenM.ImageHash.HashAlgorithms;

    public class ImageHashFacade : IDemoImageHash
    {
        private readonly IFileSystem _fileSystem;
        private readonly PerceptualHash _perceptualHash;

        public ImageHashFacade(IFileSystem fileSystem)
        {
            this._fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
            _perceptualHash = new PerceptualHash();
        }

        public ulong CalculatePerceptualHash(string filename) => CoenM.ImageHash.ImageHashExtensions.Hash(_perceptualHash, _fileSystem.OpenRead(filename));
    }
}
