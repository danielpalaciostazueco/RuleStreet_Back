using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface ICodigoPenalRepository
    {
        List<CodigoPenalDTO> GetAll();
        CodigoPenalDTO? Get(int id);
        void Add(CodigoPenalDTO codigoPenalDTO);
        void Delete(int id);
        void Update(CodigoPenalDTO codigoPenalDTO);
    }
}