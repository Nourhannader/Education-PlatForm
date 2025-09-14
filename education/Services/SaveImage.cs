namespace education.Services
{
    public class SaveImage
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public SaveImage(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadImage(IFormFile imageFile,string oldName=null)
        {
            if ( imageFile !=null && imageFile.Length>0)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif",".webp" };
                var extension = Path.GetExtension(imageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Only image files are allowed.");
                }

                //delete old image
                if (!string.IsNullOrEmpty(oldName))
                {
                    string oldFilePath = Path.Combine(uploadsFolder, oldName);
                    if (File.Exists(oldFilePath))
                        File.Delete(oldFilePath);
                }

                //save new image
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                return uniqueFileName;
            }
            return oldName;
        }
    }
}
