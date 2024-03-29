using CleanCode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Application.Repository
{
    public interface IRepository
    {
        int? SaveSpeaker(Speaker speaker);
    }
}