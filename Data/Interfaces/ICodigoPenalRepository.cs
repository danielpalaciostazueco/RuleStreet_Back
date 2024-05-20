using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Data
{
    public interface ICodigoPenalRepository
    {
        List<CodigoPenalDTO> GetAll();
        CodigoPenal? Get(int id);
        void Add(CodigoPenalDTO codigoPenalDTO);
        void Delete(int id);
        void Update(CodigoPenalDTO codigoPenalDTO);
        CodigoPenal? GetIdioma(int id);
        List<CodigoPenalDTO> GetAllIdioma();
    }
}