using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Protocol;
using System.Collections.Generic;
using System.IO;

namespace Service.UnitTest
{
    [TestClass]
    public sealed class FileServiceTests
    {
        private IFileService service;

        private string testFolderPath;

        [TestInitialize]
        public void TestInitialize()
        {
            this.testFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "ONE_PIECE");

            // 將 Thumbs.db 設為系統檔、隱藏檔
            var thumbsPath = Path.Combine(this.testFolderPath, "Thumbs.db");
            File.SetAttributes(thumbsPath, FileAttributes.System);
            File.SetAttributes(thumbsPath, FileAttributes.Hidden);

            this.service = new FileService(this.testFolderPath);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Directory.Exists(this.testFolderPath) == true)
            {
                Directory.Delete(this.testFolderPath, true);
            }
        }

        [TestMethod]
        public void GetFilesTest_預期取得檔案路徑()
        {
            var expected =
                new List<string>()
                {
                    Path.Combine(this.testFolderPath, "01_魯夫.jpg"),
                    Path.Combine(this.testFolderPath, "02_索隆.jpg"),
                    Path.Combine(this.testFolderPath, "03_騙人布.jpg"),
                    Path.Combine(this.testFolderPath, "04_娜美.jpg"),
                    Path.Combine(this.testFolderPath, "05_香吉士.jpg"),
                    Path.Combine(this.testFolderPath, "06_喬巴.jpg"),
                    Path.Combine(this.testFolderPath, "07_羅賓.jpg"),
                    Path.Combine(this.testFolderPath, "Thumbs.db"),
                };

            var actual = this.service.GetFiles();

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}