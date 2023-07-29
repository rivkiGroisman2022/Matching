using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingCampaignDAL
{
    public interface IRepository<T>
    {
        List<T> GetList();
        List<T> GetSpecific(string specific);
        bool Post(T t);
        bool Put(int id, T t);
        bool Delete(int id);
    }
}
