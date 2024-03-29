using CleanCode.Application.Repository;
using CleanCode.Domain.Models;
using CleanCode.Infrastructure.Validation;
using CleanCode.Utilities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCode.Infrastructure.Repository
{
    public class Register
    {
        private readonly IRepository _repository;

        public Register(IRepository repository)
        {
            _repository = repository;
        }

        public int? RegisterSpeaker(Speaker speaker)
        {
            var validator = new SpeakerValidator();
            if (!validator.Validate(speaker))
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet requirements.");

            speaker.RegistrationFee = CleanCode.Utilities.RegistrationFeeCalculator.CalculateRegistrationFee(speaker.Exp); ;
            //RegistrationFee = RegistrationFeeCalculator.CalculateRegistrationFee(Exp);

            try
            {
                return _repository.SaveSpeaker(speaker);
            }
            catch (Exception)
            {
                // Log exception
                throw; // Rethrow the exception
            }
        }
    }
}