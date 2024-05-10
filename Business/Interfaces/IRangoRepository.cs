using System.Collections.Generic;
using RuleStreet.Models;

namespace RuleStreet.Business
{
    public interface IRangoService
    {
        List<RangoDTO> GetAll();
        RangoDTO? Get(int id);
        void Update(RangoDTO rangoDto, int id);
    }
}