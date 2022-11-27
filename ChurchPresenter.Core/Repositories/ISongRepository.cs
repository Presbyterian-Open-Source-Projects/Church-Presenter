using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurchPresenter.Core.Repositories
{
    public interface ISongRepository
    {
        Task Add();
        Task Update();  
        Task Delete();
        Task Search();
    }
}
