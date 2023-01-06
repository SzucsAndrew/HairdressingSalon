namespace HairdressingSalon.Web.Services
{
    public class FileService
    {
        public string SaveImage(string uploadsFolder, IFormFile photo)
        {
            var extension = Path.GetExtension(photo.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        public void RemoveImage(string imagePath)
        {
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
        }
    }
}
