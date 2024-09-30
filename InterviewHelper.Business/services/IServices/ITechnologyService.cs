using intervirew_helper_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewHelper.Business.services.IServices
{
    public interface ITechnologyService
    {
        Task<IEnumerable<Technology>> GetAllTechnologiesAsync();
    }
}
