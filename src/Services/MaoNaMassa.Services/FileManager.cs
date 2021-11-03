namespace MaoNaMassa.Services
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using MaoNaMassa.Common;
    using MaoNaMassa.Data.Common.Repositories;
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class FileManager : IFileManager
    {
        private readonly IRepository<Attachment> attachmentRepository;

        public FileManager(IRepository<Attachment> attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }

        public async Task AddFileToContractAsync(IFormFile file, string contractId)
        {
            var attachmentUrl = await this.UploadAttachmentAsync(file);

            var attachment = new Attachment
            {
                Url = attachmentUrl,
                ContractId = contractId,
                Name = file.FileName.Split(".").First().ToUpper(),
                Extension = file.FileName.Split(".").Last().ToUpper(),
            };

            await this.attachmentRepository.AddAsync(attachment);
            await this.attachmentRepository.SaveChangesAsync();
        }

        public async Task<string> UploadAttachmentAsync(IFormFile attachment)
        {
            Account account = new Account(
                GlobalConstants.SystemName.ToLower(),
                GlobalConstants.CloudinaryApiKey,
                GlobalConstants.CloudinaryApiSecretKey);

            Cloudinary cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;

            using (var stream = new MemoryStream())
            {
                stream.Flush();
                await attachment.CopyToAsync(stream);
                stream.Position = 0;

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(attachment.FileName.Split(".").First(), stream),
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                var downloadableUrl = "http://res.cloudinary.com/maonamassa/image/upload/v" +
                                      $"{uploadResult.Version}/{uploadResult.PublicId}.{uploadResult.Format}";

                return downloadableUrl;
            }
        }
    }
}
