using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IMultaService
    {
        List<MultaDTO> GetAll(int idPolicia);
        MultaDTO? Get(int id);
        void Update(MultaPostDTO multa, int id);
        void Delete(int id);
        void Add(MultaPostDTO multa);
    }
}