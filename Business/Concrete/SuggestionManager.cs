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
    public class SuggestionManager : ISuggestionService
    {

        ISuggestionDal _suggestionDal;


        public SuggestionManager(ISuggestionDal suggestionDal)
        {
            _suggestionDal = suggestionDal;
        }

        public async Task Add(Suggestion suggestion)
        {
            await _suggestionDal.Insert(suggestion);
        }

        public async Task Delete(Suggestion suggestion)
        {
            await _suggestionDal.Update(suggestion);
        }

        public async Task Update(Suggestion suggestion)
        {
            await _suggestionDal.Update(suggestion);
        }

        public async Task<Suggestion> GetByID(int ID)
        {
            return await _suggestionDal.GetByID(ID);
        }

        public async Task<List<Suggestion>> GetList()
        {
            return await _suggestionDal.GetList();
        }
    }
}
