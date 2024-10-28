using In_Out_Manager.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace In_Out_Manager.Application.IServices
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
