using System.IO.Abstractions;
using System.Runtime.Versioning;

namespace ImobFeed.Core.Common;

public static class FileInfoFactoryExtensions
{
    public static ITempFileInfo NewTemp(this IFileInfoFactory factory)
    {
        string tempFileName = factory.FileSystem.Path.GetTempFileName();
        return new TempFileInfo(factory.New(tempFileName));
    }

    private sealed class TempFileInfo : ITempFileInfo
    {
        private readonly IFileInfo _fileInfo;

        public TempFileInfo(IFileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public void Dispose()
        {
            _fileInfo.Delete();
        }

        public void CreateAsSymbolicLink(string pathToTarget)
        {
            _fileInfo.CreateAsSymbolicLink(pathToTarget);
        }

        public void Delete()
        {
            _fileInfo.Delete();
        }

        public void Refresh()
        {
            _fileInfo.Refresh();
        }

        public IFileSystemInfo? ResolveLinkTarget(bool returnFinalTarget)
        {
            return _fileInfo.ResolveLinkTarget(returnFinalTarget);
        }

        public IFileSystem FileSystem => _fileInfo.FileSystem;

        public FileAttributes Attributes
        {
            get => _fileInfo.Attributes;
            set => _fileInfo.Attributes = value;
        }

        public DateTime CreationTime
        {
            get => _fileInfo.CreationTime;
            set => _fileInfo.CreationTime = value;
        }

        public DateTime CreationTimeUtc
        {
            get => _fileInfo.CreationTimeUtc;
            set => _fileInfo.CreationTimeUtc = value;
        }

        public bool Exists => _fileInfo.Exists;

        public string Extension => _fileInfo.Extension;

        public string FullName => _fileInfo.FullName;

        public DateTime LastAccessTime
        {
            get => _fileInfo.LastAccessTime;
            set => _fileInfo.LastAccessTime = value;
        }

        public DateTime LastAccessTimeUtc
        {
            get => _fileInfo.LastAccessTimeUtc;
            set => _fileInfo.LastAccessTimeUtc = value;
        }

        public DateTime LastWriteTime
        {
            get => _fileInfo.LastWriteTime;
            set => _fileInfo.LastWriteTime = value;
        }

        public DateTime LastWriteTimeUtc
        {
            get => _fileInfo.LastWriteTimeUtc;
            set => _fileInfo.LastWriteTimeUtc = value;
        }

        public string? LinkTarget => _fileInfo.LinkTarget;

        public string Name => _fileInfo.Name;

        public StreamWriter AppendText()
        {
            return _fileInfo.AppendText();
        }

        public IFileInfo CopyTo(string destFileName)
        {
            return _fileInfo.CopyTo(destFileName);
        }

        public IFileInfo CopyTo(string destFileName, bool overwrite)
        {
            return _fileInfo.CopyTo(destFileName, overwrite);
        }

        public FileSystemStream Create()
        {
            return _fileInfo.Create();
        }

        public StreamWriter CreateText()
        {
            return _fileInfo.CreateText();
        }

        [SupportedOSPlatform("windows")]
        public void Decrypt()
        {
            _fileInfo.Decrypt();
        }

        [SupportedOSPlatform("windows")]
        public void Encrypt()
        {
            _fileInfo.Encrypt();
        }

        public void MoveTo(string destFileName)
        {
            _fileInfo.MoveTo(destFileName);
        }

        public void MoveTo(string destFileName, bool overwrite)
        {
            _fileInfo.MoveTo(destFileName, overwrite);
        }

        public FileSystemStream Open(FileMode mode)
        {
            return _fileInfo.Open(mode);
        }

        public FileSystemStream Open(FileMode mode, FileAccess access)
        {
            return _fileInfo.Open(mode, access);
        }

        public FileSystemStream Open(FileMode mode, FileAccess access, FileShare share)
        {
            return _fileInfo.Open(mode, access, share);
        }

        public FileSystemStream Open(FileStreamOptions options)
        {
            return _fileInfo.Open(options);
        }

        public FileSystemStream OpenRead()
        {
            return _fileInfo.OpenRead();
        }

        public StreamReader OpenText()
        {
            return _fileInfo.OpenText();
        }

        public FileSystemStream OpenWrite()
        {
            return _fileInfo.OpenWrite();
        }

        public IFileInfo Replace(string destinationFileName, string? destinationBackupFileName)
        {
            return _fileInfo.Replace(destinationFileName, destinationBackupFileName);
        }

        public IFileInfo Replace(
            string destinationFileName,
            string? destinationBackupFileName,
            bool ignoreMetadataErrors)
        {
            return _fileInfo.Replace(destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
        }

        public IDirectoryInfo? Directory => _fileInfo.Directory;

        public string? DirectoryName => _fileInfo.DirectoryName;

        public bool IsReadOnly
        {
            get => _fileInfo.IsReadOnly;
            set => _fileInfo.IsReadOnly = value;
        }

        public long Length => _fileInfo.Length;
    }
}