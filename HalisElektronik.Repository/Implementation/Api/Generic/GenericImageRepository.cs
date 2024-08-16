using HalisElektronik.Models;
using HalisElektronik.Repositories.Implementation.Api.Inteface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.Repositories.Implementation.Api.Generic
{
    public class GenericImageRepository<T> : IGenericImageRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GenericImageRepository(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public void Add(T entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return (T)entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(int id)
        {
            try
            {
                T? type = _context.Set<T>().Find(id);
                if (type != null)
                {
                    return (T)type;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                T? type = await _context.Set<T>().FindAsync(id);
                if (type != null)
                {
                    return (T)type;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
        }
        public void Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }

        }
        public async Task<string> ImageCreate(IFormFile formFile, string fileTitle)
        {

            try
            {
                if (formFile == null || formFile.Length == 0)
                {
                    string fileName1 = "No-Image.jpg";
                    return fileName1;
                }

                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "ImageLibrary");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var newFileName = $"{fileTitle}_{Guid.NewGuid()}_{Path.GetExtension(formFile.FileName)}";
                var filePath = Path.Combine(uploadsFolderPath, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                return newFileName;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void ImageDelete(string imageName)
        {
            try
            {
                if (!String.IsNullOrEmpty(imageName))
                {
                    string webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "ImageLibrary");
                    if (System.IO.File.Exists(webRootPath + "//" + imageName))
                    {
                        System.IO.File.Delete(webRootPath + "//" + imageName);
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }
        public List<ProductImage> ProductImageGet(int id)
        {
            try
            {
                var model = _context.ProductImage.Where(x => x.ProductId == id).ToList();
                if (model != null)
                {
                    return model;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
