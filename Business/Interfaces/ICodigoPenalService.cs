using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface ICodigoPenalService
    {
        List<CodigoPenalDTO> GetAll();
        CodigoPenalDTO? Get(int id);
        void Delete(int id);
        void Update(CodigoPenalDTO codigoPenalDTO);
    }
}