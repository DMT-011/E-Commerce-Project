﻿namespace E_commerce_Project.Models.Services.FileService;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly ILogger<FileService> _logger;
    private readonly string _uploadFolder;
    

    public FileService(IWebHostEnvironment hostingEnvironment, ILogger<FileService> logger)
    {
        _hostingEnvironment = hostingEnvironment;
        _logger = logger;
        _uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
        EnsureFolderExist(_uploadFolder);
    }
    
    public void EnsureFolderExist(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            _logger.LogInformation($"Created folder: {folderPath}");
        }
        else
        {
            _logger.LogWarning($"Folder already exists: {folderPath}");
        }
    }

    public string GetUploadsFolder(string subFolder)
    {
        var fullPath = Path.Combine(_uploadFolder, subFolder);
        EnsureFolderExist(fullPath);
        return fullPath;
    }

    public string GetUploadsFolderByIdItem(string subfolder, string idItem)
    {
        var fullPath = Path.Combine(_uploadFolder, subfolder, idItem);
        EnsureFolderExist(fullPath);
        return fullPath;
    }
    
    public async Task<string> SaveFileAsync(IFormFile file, string fullPath)
    {
        var savePath = Path.Combine(fullPath, file.FileName);
        using var stream = new FileStream(savePath, FileMode.Create);
        await file.CopyToAsync(stream);
        
        return savePath;
    }
    
    public void DeleteFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new Exception("File not exists");
        }
       
        File.Delete(filePath);
    }

    public void DeleteFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            throw new Exception("Folder not exists");
        }

        Directory.Delete(folderPath, true);
    }
}