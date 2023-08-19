using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {

        IImageDal _imageDal;


        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public async Task Add(Image image)
        {
            await _imageDal.Insert(image);
        }

        public async Task Delete(Image image)
        {
            await _imageDal.Delete(image);
        }

        public async Task Update(Image image)
        {
            await _imageDal.Update(image);
        }

        public async Task<Image> GetByID(int ID)
        {
            return await _imageDal.GetByID(ID);
        }

        public async Task<List<Image>> GetList()
        {
            return await _imageDal.GetList();
        }

        public async Task<Image> GetImageByName(string Name)
        {
            return await _imageDal.GetImageByName(Name);
        }

        public async Task<List<string>> GetImageNames()
        {
            return await _imageDal.GetImageNames();
        }
    }
}
