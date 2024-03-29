using CleanCode.Application.Repository;
using CleanCode.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.Repository
{
    public class SpeakerRepository : IRepository
    {
        public int? SaveSpeaker(Speaker speaker)
        {
            // Implement saving logic here
            Console.WriteLine("Speaker saved successfully.");
            return 1; // For demonstration
        }
    }
}