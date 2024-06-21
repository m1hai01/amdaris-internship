using Application.Abstractions;
using Application.Commands.Treatment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Treatment
{
    public class DeleteTreatmentCommandHandler : IRequestHandler<DeleteTreatmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTreatmentCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTreatmentCommand request, CancellationToken cancellationToken)
        {
            //var treatment = await _unitOfWork.TreatmentRepository.GetByIdAsync(request.Id);

            //if (treatment == null)
            //{
            //    throw new ArgumentException("Treatment not found");
            //}

            await _unitOfWork.TreatmentRepository.DeleteAsync(request.Id);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}