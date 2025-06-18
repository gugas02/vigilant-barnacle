using Ambev.DeveloperEvaluation.Common.Transaction;

namespace Ambev.DeveloperEvaluation.Application.Common;

public class BaseHandler
{
    private IUnitOfWork _unitOfWork;

    public BaseHandler(IUnitOfWork uof)
    {
        _unitOfWork = uof;
    }

    public void Commit()
    {
        _unitOfWork.Commit();
    }
}