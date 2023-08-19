using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageService : GenericService<Image>
    {

        Task<List<string>> GetImageNames();
        Task<Image> GetImageByName(string Name);

    }
}
